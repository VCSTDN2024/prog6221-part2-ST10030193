using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    internal class UserQuery
    {
        //Dictionary that will have all responses available
        private ReadOnlyDictionary<string, BotResponse> botResponses;
        
        private UserProfile user = new UserProfile();
        private string name { get; set; }
        private string question { get; set; }

        private bool exit = false;

        public Random r = new Random();



        //Constructures 
        public UserQuery(string name, string question)
        {
            this.name = name;
            this.question = question;
        }

        public void searchListDisplay()
        {

            Console.WriteLine("Bot: Here's what I can help you with!\n");
            Console.WriteLine(" Topics you can ask about:");
            Console.WriteLine("  1. Purpose");
            Console.WriteLine("  2. Ask (To view again )");
            Console.WriteLine("  3. Phishing Attack");
            Console.WriteLine("  4. Password Attacks");
            Console.WriteLine("  5. Suspicious Links");
            Console.WriteLine("  6. Ransomware Attack");
            Console.WriteLine("  7. Denial of Service (DoS) Attack");
            Console.WriteLine("  8. Malware");
            Console.WriteLine("  9. Spamming");
            Console.WriteLine(" 10. Exit (To close the program)\n");

            Console.WriteLine(" Type the *name* of the topic you want to learn about (e.g., 'Phishing Attack'):");
        }

        public void responses()
        {
            responseDictionary();

            while (!exit)
            {
                bool foundResponse = false; // Track if bot responded in this cycle

                if (string.IsNullOrWhiteSpace(question))
                {
                    Console.WriteLine("Please type something or 'exit' to quit.");
                    foundResponse = true;
                }
                else if (question == "ask")
                {
                    searchListDisplay();
                    foundResponse = true;
                }
                else if (question.Contains("tip"))
                {
                    foreach (var pair in botResponses)
                    {
                        if (question.Contains(pair.Key.ToLower()) && pair.Value.PreventionTips != null && pair.Value.PreventionTips.Any())
                        {
                            var tip = pair.Value.PreventionTips[r.Next(pair.Value.PreventionTips.Count)];
                            Console.WriteLine($"\nBot Tip on {pair.Key}: {tip}");
                            foundResponse = true;
                            break;
                        }
                    }
                    if (!foundResponse)
                    {
                        Console.WriteLine("Sorry, I don't have any tips on that topic.");
                        foundResponse = true;
                    }
                }
                else
                {
                    foreach (var pair in botResponses)
                    {
                        if (question.Contains(pair.Key.ToLower()))
                        {
                            Console.WriteLine($"\nBot: {pair.Value.Response}");

                            if (pair.Value.PreventionTips != null && pair.Value.PreventionTips.Count > 0)
                            {
                                Console.WriteLine("\nPrevention Tips:");
                                foreach (var tip in pair.Value.PreventionTips)
                                {
                                    Console.WriteLine($"- {tip}");
                                }
                            }
                            foundResponse = true;
                            break;
                        }
                    }
                }

                // Only call additionalResponses IF no other response was found
                if (!foundResponse)
                {
                    additionalResponses(question);
                }

                if (question.Contains("exit"))
                {
                    Console.WriteLine("Goodbye and do not forget to stay safe online!");
                    exit = true;
                    break;
                }

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{name}: ");
                question = Console.ReadLine()?.ToLower() ?? "";
                Console.ResetColor();
            }
        }



        private void responseDictionary()
        {
            var temp = new Dictionary<string, BotResponse>
    {
        { "purpose", new BotResponse("I'm here to help you learn about cybersecurity threats and provide guidance on avoiding common traps :)") },

        { "phishing", new BotResponse(
            "A phishing attack is when a scammer tries to trick you into giving up sensitive info—like passwords, credit card numbers, or personal details—by pretending to be someone you trust.",
            PreventionTips: new List<string>
            {
                "Don’t click on links or download attachments from sketchy emails.",
                "Check the sender’s email address carefully—it might look 'off'.",
                "Look for weird grammar or urgent scare tactics.",
                "Always type website URLs manually instead of clicking email links.",
                "Use two-factor authentication wherever possible."
            })
        },

        { "password", new BotResponse(
            "Password attacks are when cybercriminals try to guess or steal your password to break into your accounts. They may use brute force or stolen passwords from breaches.",
            PreventionTips: new List<string>
            {
                "Use strong, unique passwords for every account.",
                "Turn on two-factor authentication (2FA).",
                "Don’t use obvious passwords like '123456' or 'password'.",
                "Use a password manager to keep track of passwords.",
                "Change passwords regularly—especially after a breach."
            })
        },

        { "suspicious links", new BotResponse(
            "Suspicious links may appear legit but lead to malicious sites. They often come via email, social media, or messages.",
            PreventionTips: new List<string>
            {
                "Hover over links before clicking to preview the URL.",
                "Avoid links with weird characters or lots of hyphens.",
                "Use a link expander for shortened URLs.",
                "Avoid clicking links from unknown senders.",
                "Visit official sites directly instead of using email links."
            })
        },

        { "ransomware", new BotResponse(
            "Ransomware is malicious software that blocks access to your data unless a ransom is paid.",
            PreventionTips: new List<string>
            {
                "Back up important files and keep backups offline.",
                "Avoid clicking unknown links or attachments.",
                "Keep your system updated with security patches.",
                "Use reputable antivirus software.",
                "Enable real-time protection features."
            })
        },

        { "denial of services", new BotResponse(
            "A Denial of Service attack floods a system with traffic, making it slow or unusable.",
            PreventionTips: new List<string>
            {
                "Use firewalls and intrusion detection systems.",
                "Employ rate limiting and traffic filtering.",
                "Partner with DDoS protection services.",
                "Patch system vulnerabilities quickly."
            })
        },

        { "malware", new BotResponse(
            "Malware is software designed to harm, exploit, or control systems. It includes viruses, worms, spyware, and ransomware.",
            PreventionTips: new List<string>
            {
                "Install and update a trusted antivirus.",
                "Don’t download software from unknown sources.",
                "Avoid suspicious links or popups.",
                "Keep your OS and software patched."
            })
        },

        { "spamming", new BotResponse(
            "Spam is unwanted digital junk mail. Some spam can hide malicious links or downloads.",
            PreventionTips: new List<string>
            {
                "Never click on links or download attachments from unknown senders.",
                "Check for suspicious or unusual email addresses.",
                "Ignore urgent or threatening messages.",
                "Use spam filters and report suspicious emails.",
                "Go directly to the official site, not the provided link."
            })
        },

        { "hello", new BotResponse("Hello!! What can I help you with?") },
        { "hey", new BotResponse("Hi :)!") }
    };

            botResponses = new ReadOnlyDictionary<string, BotResponse>(temp);
        }

        private void conversationFlow()
        {
            //output random conversation continuers to engage the user

            List<string> chatbotPrompts = new List<string>
{
    "Is there anything else you’d like to know?",
    "Feel free to ask me another question when you're ready.",
    "What else can I help you with today?",
    "I'm here if you have more questions—just ask!",
    "Need more info on something else?",
    "Would you like to explore another topic?",
    "Happy to keep helping—what would you like to ask next?",
    "Anything else on your mind?",
    "You can ask me anything else whenever you're ready.",
    "Let me know if you’d like to continue or switch topics.",
    "I'm here if anything else comes up!",
    "Still curious? Ask away!",
    "What would you like to explore next?",
    "If you’re wondering about anything else, just type it in.",
    "I’ve got time...want to keep going?",
    "Just let me know if there’s more you'd like to learn.",
    "You’re doing great—ready for your next question?"
};

            int index = r.Next(chatbotPrompts.Count);
            Console.WriteLine(chatbotPrompts[index]);

        }

        string AnalyzeSentiment(string message)
        {
            var positiveWords = new[] { "good", "great", "happy", "awesome", "love", "fantastic", "amazing","excited" };
            var negativeWords = new[] { "bad", "sad", "angry", "hate", "terrible", "awful", "upset" };

            message = message.ToLower();

            int score = 0;
            foreach (var word in positiveWords)
                if (message.Contains(word)) score++;

            foreach (var word in negativeWords)
                if (message.Contains(word)) score--;

            if (score > 0)
                return "positive";
            else if (score < 0)
                return "negative";
            else
                return "neutral";
        }

        void TryUpdateUserProfile(string input)
        {
            input = input.ToLower();

            // Look for interest (e.g. "I love painting")
            if (input.Contains("i love") || input.Contains("i like") || input.Contains("i enjoy")||input.Contains("interest"))
            {
                string[] triggers = { "i love", "i like", "i enjoy","interest"};
                foreach (var trigger in triggers)
                {
                    if (input.Contains(trigger))
                    {
                        int index = input.IndexOf(trigger) + trigger.Length;
                        string interest = input.Substring(index).Trim(new char[] { '.', '!', '?', ' ' });
                        user.Interest = interest;
                        Console.WriteLine($"🎯 I’ll remember you like {user.Interest}.");
                        break;
                    }
                }
            }

            // Look for favourite topic (e.g. "My favourite topic is history")
            if (input.Contains("my favorite topic is") || input.Contains("my favourite topic is"))
            {
                string phrase = input.Contains("my favorite topic is") ? "my favorite topic is" : "my favourite topic is";
                int index = input.IndexOf(phrase) + phrase.Length;
                string topic = input.Substring(index).Trim(new char[] { '.', '!', '?', ' ' });
                user.FavouriteTopic = topic;
                Console.WriteLine($"📚 Got it! Your favourite topic is {user.FavouriteTopic}.");
            }
        }

        void additionalResponses(string input)
        {
            TryUpdateUserProfile(input);
            string sentiment = AnalyzeSentiment(input);

            if (input.ToLower().Contains("exit"))
            {
                Console.WriteLine("👋 Goodbye!");
                exit = true;
                return;
            }

            if (!string.IsNullOrEmpty(user.Interest))
            {
                if (sentiment == "positive")
                    Console.WriteLine($"😊 Great to hear! Doing more with {user.Interest} must be fun.");
                else if (sentiment == "negative")
                    Console.WriteLine($"😟 Sorry you’re feeling down. Maybe {user.Interest} can cheer you up.");
                else
                    Console.WriteLine($"🤔 How about spending some time with {user.Interest}?");
            }
            else
            {
                if (sentiment == "positive")
                    Console.WriteLine("😊 Nice to hear you’re doing well!");
                else if (sentiment == "negative")
                    Console.WriteLine("😔 I’m here if you want to talk.");
                else
                    Console.WriteLine("🤖 Tell me what you like or how you’re feeling.");
            }

            if (!string.IsNullOrEmpty(user.FavouriteTopic) && r.Next(2) == 0) // 50% chance to remind
            {
                Console.WriteLine($"📚 Remember, your favourite topic is {user.FavouriteTopic}!");
            }

            conversationFlow(); // Your existing method for random prompts
        }


    }

}

