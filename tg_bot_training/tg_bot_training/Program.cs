

using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

class Programm
{
    private static ITelegramBotClient _botClient;
    private static ReceiverOptions _receiverOptions;
    static async Task Main()
    {

        _botClient = new TelegramBotClient("6377769643:AAH9RYvhIMq2aJcNOS2j4Vfytv232wJlNX0"); // Присваиваем нашей переменной значение, в параметре передаем Token, полученный от BotFather
        _receiverOptions = new ReceiverOptions // Также присваем значение настройкам бота
        {
            AllowedUpdates = new[] // Тут указываем типы получаемых Update`ов, о них подробнее расказано тут 
            {
                UpdateType.Message, // Сообщения (текст, фото/видео, голосовые/видео сообщения и т.д.)
                UpdateType.CallbackQuery
            },
            // Параметр, отвечающий за обработку сообщений, пришедших за то время, когда ваш бот был оффлайн
            // True - не обрабатывать, False (стоит по умолчанию) - обрабаывать
            ThrowPendingUpdates = true,
        };

        using var cts = new CancellationTokenSource();

        // UpdateHander - обработчик приходящих Update`ов
        // ErrorHandler - обработчик ошибок, связанных с Bot API
        _botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cts.Token); // Запускаем бота

        var me = await _botClient.GetMeAsync(); // Создаем переменную, в которую помещаем информацию о нашем
                                                // боте.
        Console.WriteLine($"{me.FirstName} запущен!");

        await Task.Delay(-1); // Устанавливаем бесконечную задержку, чтобы наш бот работал постоянно
        
    }
    private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        // Обязательно ставим блок try-catch, чтобы наш бот не "падал" в случае каких-либо ошибок
        try
        {
            // Сразу же ставим конструкцию switch, чтобы обрабатывать приходящие Update
            switch (update.Type)
            {
                case UpdateType.Message:
                    {
                        // эта переменная будет содержать в себе все связанное с сообщениями
                        var message = update.Message;

                        // From - это от кого пришло сообщение
                        var user = message.From;

                        // Выводим на экран то, что пишут нашему боту, а также небольшую информацию об отправителе
                        Console.WriteLine($"{user.FirstName} ({user.Id}) написал сообщение: {message.Text}");

                        // Chat - содержит всю информацию о чате
                        var chat = message.Chat;

                        // Добавляем проверку на тип Message
                        switch (message.Type)
                        {
                            // Тут понятно, текстовый тип
                            case MessageType.Text:
                                {
                                    // тут обрабатываем команду /start, остальные аналогично
                                    if (message.Text == "/start")
                                    {
                                        await botClient.SendTextMessageAsync(
                                            chat.Id,
                                            "Здарова нахуй, тебя приветсвует великий ЖЕНЕК\n" +
                                            "сеййчас будем с тобой, куском уебка базарить\n" +
                                            "Выбирай каким обзразом:\n" +
                                            "Ногами: /inline\n" +
                                            "Хуем: /reply\n");
                                        return;
                                    }

                                    if (message.Text == "/inline")
                                    {
                                        // Тут создаем нашу клавиатуру
                                        var inlineKeyboard = new InlineKeyboardMarkup(
                                            new List<InlineKeyboardButton[]>() // здесь создаем лист (массив), который содрежит в себе массив из класса кнопок
                                            {
                                        // Каждый новый массив - это дополнительные строки,
                                        // а каждая дополнительная строка (кнопка) в массиве - это добавление ряда

                                        new InlineKeyboardButton[] // тут создаем массив кнопок
                                        {
                                            InlineKeyboardButton.WithUrl("пошел ка ты нахуй", "https://www.google.com/search?q=%D1%84%D0%B0%D0%BA&sca_esv=572931913&tbm=isch&sxsrf=AM9HkKlMavkom_jBk2BucxP4dAgdqvCmSA:1697132970572&source=lnms&sa=X&ved=2ahUKEwiIuuP-iPGBAxUQr4sKHdsdB0IQ_AUoAXoECAEQAw&biw=1920&bih=963&dpr=1#imgrc=9KVB0dfYuEDb7M")
                                            
                                            ,
                                        },
                                        new InlineKeyboardButton[]
                                        {
                                            InlineKeyboardButton.WithUrl("Пойдешь сюда, я твою мать трахну", "https://pornokaef.net/videos/%D0%B5%D0%B1%D1%83%D1%82-%D0%BC%D0%B0%D1%82%D1%8C-%D0%BF%D1%80%D0%B8-%D1%81%D1%8B%D0%BD%D0%B5"),
                                        
                                        },
                                        new InlineKeyboardButton[]
                                        {
                                            InlineKeyboardButton.WithUrl("ЭЭЭ, БЛЯ, иди сюда назуй", "https://www.reddit.com/r/Pikabu/comments/s3yatw/%D1%8F%D0%B7%D1%8B%D0%BA_%D0%BF%D0%BE%D0%BF%D1%83%D0%B3%D0%B0%D1%8F_%D0%B2%D0%B8%D0%B4%D0%B5%D0%BB%D0%B8_%D0%B2%D0%BE%D1%82_%D0%B2%D0%B0%D0%BC_%D1%85%D1%83%D0%B9_%D0%B5%D1%85%D0%B8%D0%B4%D0%BD%D1%8B/?rdt=33793")
                                        },
                                            });
                                        
                                        await botClient.SendTextMessageAsync(
                                            chat.Id,
                                            "Это inline клавиатура!",
                                            replyMarkup: inlineKeyboard); // Все клавиатуры передаются в параметр replyMarkup

                                        return;
                                    }

                                    if (message.Text == "/reply")
                                    {
                                        // Тут все аналогично Inline клавиатуре, только меняются классы
                                        // НО! Тут потребуется дополнительно указать один параметр, чтобы
                                        // клавиатура выглядела нормально, а не как абы что

                                        var replyKeyboard = new ReplyKeyboardMarkup(
                                            new List<KeyboardButton[]>()
                                            {
                                        new KeyboardButton[]
                                        {
                                            new KeyboardButton("Привет"),
                                            new KeyboardButton("'Протянуть руку'"),
                                        },
                                        new KeyboardButton[]
                                        {
                                            new KeyboardButton("Научи меня стрелять")
                                        },
                                        new KeyboardButton[]
                                        {
                                            new KeyboardButton("Трахни мою собаку по братски")
                                        }
                                            })
                                        {
                                            // автоматическое изменение размера клавиатуры, если не стоит true,
                                            // тогда клавиатура растягивается чуть ли не до луны,
                                            // проверить можете сами
                                            ResizeKeyboard = true,
                                        };

                                        await botClient.SendTextMessageAsync(
                                            chat.Id,
                                            "reply keyboard",
                                            replyMarkup: replyKeyboard); // опять передаем клавиатуру в параметр replyMarkup

                                        return;
                                    }

                                    if (message.Text == "привет")
                                    {
                                        await botClient.SendTextMessageAsync(
                                            chat.Id,
                                            "за 15 рублей",
                                            replyToMessageId: message.MessageId);

                                        return;
                                    }

                                    if (message.Text == "'Протянуть руку'")
                                    {
                                        await botClient.SendTextMessageAsync(
                                            chat.Id,
                                            "сам блять пиши",
                                            replyToMessageId: message.MessageId);

                                        return;
                                    }
                                    if (message.Text == "Научи меня стрелять")
                                    {
                                        await botClient.SendTextMessageAsync(
                                            chat.Id,
                                            "сам блять пиши",
                                            replyToMessageId: message.MessageId);

                                        return;
                                    }
                                    if (message.Text == "Трахни мою собаку по братски")
                                    {
                                        await botClient.SendTextMessageAsync(
                                            chat.Id,
                                            "сам блять пиши",
                                            replyToMessageId: message.MessageId);

                                        return;
                                    }

                                    return;
                                }

                            // Добавил default , чтобы показать вам разницу типов Message
                            default:
                                {
                                    await botClient.SendTextMessageAsync(
                                        chat.Id,
                                        "Используй только текст!");
                                    return;
                                }
                        }

                        return;
                    }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    private static Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken)
    {
        // Тут создадим переменную, в которую поместим код ошибки и её сообщение 
        var ErrorMessage = error switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => error.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }
}
