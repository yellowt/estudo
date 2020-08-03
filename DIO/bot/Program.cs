using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Awesome
{
    class Program {
    static ITelegramBotClient botClient;

    static void Main() {
      // Abaixo, insira como string o token que você recebeu do Botfather
      botClient = new TelegramBotClient("SEU_TELEGRAM_TOKEN");
      
      var me = botClient.GetMeAsync().Result;
      Console.WriteLine(
        $"Olá, Mundo! Eu sou o usuário {me.Id} e meu nome é {me.FirstName}."
      );

      botClient.OnMessage += Bot_OnMessage;
      botClient.StartReceiving();

      Console.WriteLine("Pressione qualquer tecla para sair");
      Console.ReadKey();

      botClient.StopReceiving();
    }

//        public Message Message { get => message; set => message = value; }

        static async void Bot_OnMessage(object sender, MessageEventArgs e) {
      if (e.Message.Text != null)
      {
        Console.WriteLine($"Recebeu uma mensagem no chat {e.Message.Chat.Id}.");

        await botClient.SendTextMessageAsync(
          chatId: e.Message.Chat,
          text:   "Você disse:\n" + e.Message.Text
        );
      }
      
    /*    Message message = await botClient.SendTextMessageAsync(
            chatId: 819414529, //e.Message.Chat, // or a chat id: 123456789
            text: "Trying *all the parameters* of `sendMessage` method",
            parseMode: ParseMode.Markdown,
            disableNotification: true,
            replyToMessageId: e.Message.MessageId,
            replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl(
                "Check sendMessage method",
                "https://core.telegram.org/bots/api#sendmessage"
            ))
        ); */
      /*{ Message pollMessage = await botClient.SendPollAsync(
            chatId: "@group_or_channel_username",
            question: "Did you ever hear the tragedy of Darth Plagueis The Wise?",
            options: new []
            {
                "Yes for the hundredth time!",
                "No, who`s that?"
            }
        );
      }*/
       
          
    }
  }
}

/*
namespace Awesome {
  class Program {
    static void Main() {
      var botClient = new TelegramBotClient("1077480327:AAFiqQkbvzC72t87jKKNca-YLBqrPYt-XbA");
      var me = botClient.GetMeAsync().Result;
      Console.WriteLine(
        $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
      );
    }
  }
}
*/