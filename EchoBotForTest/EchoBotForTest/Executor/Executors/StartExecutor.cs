﻿using System;
using System.Threading.Tasks;
using EchoBotForTest.Command.Commands;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EchoBotForTest.Executor.Executors
{
    public class StartExecutor : IExecutor<StartCommandType>
    {
        public async Task ExecuteAsync(Telegram.Bot.Types.Message message, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}
