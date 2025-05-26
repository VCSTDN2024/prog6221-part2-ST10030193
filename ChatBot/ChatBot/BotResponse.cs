using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    internal class BotResponse
    {
       
            public string Response { get; set; }
            public List<string> PreventionTips { get; set; }

            public BotResponse(string response, List<string> PreventionTips = null)
            {
                Response = response;
                this.PreventionTips = PreventionTips ?? new List<string>();
            }
        }
    }

