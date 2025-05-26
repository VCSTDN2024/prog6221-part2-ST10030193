# 💻 Cybersecurity ChatBot

A simple interactive console-based chatbot built in C# that educates users about common cybersecurity threats and how to prevent them.

---

## 🚀 Features

- Responds to user questions about common cybersecurity topics.
- Provides detailed definitions and explanations.
- Displays relevant **prevention tips** for each topic.
- Handles greetings, unknown queries, and allows users to exit gracefully.
- Offers a **random tip** on request via the `tip <topic>` command.
- Supports case-insensitive and keyword-based topic matching.

---

## 🛡️ Supported Topics

Type `ask` in the chat to get a list of supported topics. Current examples include:

- phishing  
- password  
- suspicious links  
- ransomware  
- denial of services  
- malware  
- spamming  

---

## 📦 Project Structure

```plaintext
CyberSecurityBot/
│
├── Program.cs             # Main entry point
├── Bot.cs                 # Contains chatbot logic
├── BotResponse.cs         # Model holding topic response and prevention tips
└── README.md              # Project documentation
