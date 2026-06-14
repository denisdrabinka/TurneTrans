# TurneTrans

Cross-platform mobile app (.NET MAUI) for the **Turne-Trans** transportation and tour scheduling platform.

## Platforms

- Android
- iOS
- macOS (Catalyst)
- Windows

## Features

- Embedded web client for the Turne-Trans scheduling system
- Push notifications via **Firebase Cloud Messaging (FCM)**
- Device token management for notification routing

## Tech Stack

| | |
|---|---|
| Framework | .NET MAUI (.NET 8) |
| Notifications | Xamarin.Firebase.Messaging |
| UI | MAUI ContentPage / WebView |

## Requirements

- .NET 8 SDK
- For Android: Android SDK 23+
- For iOS/macOS: Xcode 14+
- Firebase project with `google-services.json` configured
