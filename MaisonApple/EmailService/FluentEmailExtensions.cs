﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FluentEmail.Core.Interfaces;
//using FluentEmail.Smtp;
//using Microsoft.Extensions.DependencyInjection;

//namespace EmailService
//{
//    public static class FluentEmailExtensions
//    {
//        public static void AddFluentEmail(this IServiceCollection services,
//            ConfigurationManager configuration)
//        {
//            var emailSettings = configuration.GetSection("EmailSettings");
//            var defaultFromEmail = emailSettings["DefaultFromEmail"];
//            var host = emailSettings["Host"];
//            var port = emailSettings.GetValue<int>("Port");
//            services.AddFluentEmail(defaultFromEmail);
//            services.AddSingleton<ISender>(x => new SmtpSender(new SmtpClient(host, port))); // I'm using dev mode using 'smtp4dev' hence i'm only using host and port
//        }
//    }
//}
