using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.Extensions.Configuration;

namespace NotificationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.AddCommandLine(args);
            builder.AddEnvironmentVariables("DEMO_");
            var config = builder.Build();

            TwilioClient.Init(config["SIGNALWIRE_PROJECT"], config["SIGNALWIRE_TOKEN"], new Dictionary<string, object> { ["signalwireSpaceUrl"] = config["SIGNALWIRE_SPACE"] });

            Console.WriteLine($"Sending {config["mode"]} from {config["from"]} to {config["to"]} with message: {config["message"]}");

            if (config["mode"] == "voice") {
                var encoded = Uri.EscapeUriString(config["message"]);
                var uri = $"https://lpradovera.signalwire.com/laml-bins/ac521fa5-038d-400f-9a8d-cd2d38ba7fb0?message={encoded}";

                var call = CallResource.Create(
                    url: new Uri(uri),
                    to: new Twilio.Types.PhoneNumber(config["to"]),
                    from: new Twilio.Types.PhoneNumber(config["from"])
                );
                Console.WriteLine(call.Sid);
            } else if (config["mode"] == "text") {
                var message = MessageResource.Create(
                    to: new Twilio.Types.PhoneNumber(config["to"]),
                    from: new Twilio.Types.PhoneNumber(config["from"]),
                    body: config["message"]
                );
                Console.WriteLine(message.Sid);

            } else {
                Console.WriteLine("Unrecognized mode!");
            }
        }
    }
}
