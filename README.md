MauiCamera2App
This repository contains a sample application demonstrating the use of the Camera2 API in .NET MAUI. It is based on the original work from the Xam-Android-Camera2-Sample repository and has been adapted to work with .NET MAUI.

Overview
The MauiCamera2App project provides a functional example of integrating the Camera2 API with .NET MAUI. This application showcases how to create a custom camera preview and handle camera operations using the modern Camera2 API in a cross-platform .NET MAUI application.

Features
Camera preview using Camera2 API
Integration with .NET MAUI
Custom handler implementation for cross-platform support
Requirements
.NET 8.0 or later
Visual Studio 2022 or later with .NET MAUI workload installed
Getting Started
To get started with this project, follow these steps:

Clone the repository:

sh
Code kopieren
git clone https://github.com/CRI-IGH/MauiCamera2App.git
cd MauiCamera2App
Open the solution file (MauiCamera2App.sln) in Visual Studio.

Build and run the project on your preferred Android emulator or device.

Project Structure
MainPage.xaml: The main page containing the camera preview.
MainPage.xaml.cs: Code-behind file for MainPage.xaml.
CameraPreview.cs: Custom view for displaying the camera preview.
CameraPreviewHandler.cs: Custom handler for the CameraPreview view on Android.
Camera2Fragment.cs: Fragment implementation for managing the camera preview on Android.
MainActivity.cs: Main activity class for the Android project.
Acknowledgements
This project is based on the original work from the Xam-Android-Camera2-Sample repository. We have adapted the original Xamarin.Android implementation to work with .NET MAUI to provide a modern, cross-platform solution for using the Camera2 API.

License
This project is licensed under the MIT License. See the LICENSE file for details.
