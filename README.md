# Discord Bot Template

[![Build & Tests](https://github.com/ktutak1337/Discord-Bot-Template/actions/workflows/github-actions.yaml/badge.svg)](https://github.com/ktutak1337/Discord-Bot-Template/actions/workflows/github-actions.yaml)
[![NuGet Package](https://img.shields.io/badge/.NET%20-8.0-blue.svg)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
[![GitHub license](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ktutak1337/Discord-Bot-Template/blob/main/LICENSE.md)

This repository serves as a Discord Bot template designed to expedite the process of creating new Discord bots. The project comes with a pre-configured setup for the bot, along with a practical example showcasing the handling of voice messages and sending them to a specified webhook.


## Getting Started

Before you start running the project, you'll need to perform the following steps:

### 1. Create a Discord Application

To use this Discord Bot template, you first need to create a **Discord Application** in the [Discord Developer Portal](https://discord.com/developers/docs/getting-started). Follow these steps:

- Go to [Discord Developer Portal](https://discord.com/developers/docs/getting-started) and create a new application.
- During the application creation, generate a URL for your bot with the following permissions:
  - **Scope:** Select `applications.commands` and `bot`.
  - **Bot Permissions:** Choose `Administrator` or set specific permissions based on your bot's requirements.

![bot-config](https://github.com/ktutak1337/Discord-Bot-Template/blob/main/assets/images/bot-config.jpg)

### 2. Project Requirements

Before running the project, ensure that you meet the following requirements:

### Install .NET SDK

Make sure you have the .NET SDK installed on your system. You can download and install it from the following link: [.NET 8 SDK Download](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

### Choose an Integrated Development Environment (IDE)

Select one of the following IDEs to work with this project:

- Visual Studio Code: Download it from [Visual Studio Code](https://code.visualstudio.com/Download)
- Visual Studio Community: Get it from [Visual Studio Community](https://visualstudio.microsoft.com/vs/community/)
- JetBrains Rider: Download Rider from [JetBrains Rider](https://www.jetbrains.com/rider/download/)

This structure guides the user through the Discord Developer Portal configuration process before moving on to installation and project requirements, providing a logical and intuitive sequence of steps.

### Running the Project

Follow these steps to run the project:

## 1. Set Up Secrets

Before running the project, you'll need to set up some secrets. You can either follow the command-line instructions below or use Visual Studio for a more convenient setup.

### Command-Line Setup

Run the following commands from the main directory:

1. Initialize user secrets:
    ```shell
    dotnet user-secrets init
    ```

2. Set `discord:token` secret:
    ```shell
    dotnet user-secrets set "discord:token" "your_discord_token" --project src/DiscordBotTemplate
    ```

3. Set `integration:webhookUrl` secret:
    ```shell
    dotnet user-secrets set "integration:webhookUrl" "your_webhook_url" --project src/DiscordBotTemplate
    ```

### Visual Studio Setup

Optionally, you can set up secrets using Visual Studio:

1. Right-click on your project in Visual Studio.
2. Select "Manage User Secrets."
3. Paste and complete the following JSON:

```json
{
  "discord": {
    "token": "your_discord_token"
  },
  "integration": {
    "webhookUrl": "your_webhook_url"
  }
}
```

> **NOTE**
> User secrets are recommended for development environments to avoid accidentally committing sensitive information to a remote Git repository.

**Production Environment**

For a production environment, it's crucial not to leave plain-text secrets in the `appsettings.json` file. Instead:

- Encrypt secrets or use a vault solution such as Azure Vault or HashiCorp Vault.
- Consider leveraging environment variables within your GitHub repository.
- Remember to follow security best practices to protect sensitive information in a production setting.

### 2. Restore Dependencies
To restore project dependencies, execute the following command:

```shell
dotnet restore
```

### :rocket: 3. Run the application
Change to the app directory and start the application by running:

```shell
cd src/DiscordBotTemplate
dotnet run
```

### :star: Enjoying the Project?
If you find this project helpful, learned something new, or using it to kickstart your own solution, consider showing your appreciation by giving it a star! Your support means a lot. Thank you! :rocket:
