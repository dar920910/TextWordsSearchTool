# :mag: Text Words Search Tool

:pushpin: Currently, the project is included to my summary repository of demo projects:

:link: [Demo Projects Workshop 2023+](https://github.com/dar920910/Demo-Projects-Workshop)

---

## :sound: About the Project History

This project implements a tool to find *entries of text words* in a custom text file.

Project's idea was taken from a test project created me when passing an interview in 2019.
I added more features to its initial idea and extended project's codebase infrastructure.

## :question: About the Repository Structure

This repository contains the following projects:

- **TextWordsSearch.Library** - implements the .NET class library for the project
- **TextWordsSearch.Testing** - implements NUnit-based unit tests for the project
- **TextWordsSearch.App.CLI** - implements the console application for the project
- **TextWordsSearch.App.Web** - implements the ASP.NET Core Razor Pages web application for the project

The repository also contains example files to testing the app. You may try these examples via running scripts:

- **Examples/Example1_Small**
  - Windows: Run-AppDemo-Example1-Small.ps1
  - Docker: demo-example1-small.bash
- **Examples/Example2_Large**
  - Windows: Run-AppDemo-Example2-Large.ps1
  - Docker: demo-example2-large.bash
- **Examples/Example3_Huge**
  - Windows: Run-AppDemo-example3-Huge.ps1
  - Docker: demo-example3-huge.bash

---

## :beginner: Quick Start

### :globe_with_meridians: Using Project's Web Application

1. Run the web application via Docker (see the "Run via Docker" section below).
2. Open either <https://localhost:5002> or <http://localhost:5001> URL in your web browser.
3. Upload a text file and then click the "Read the Uploaded File" button on the webpage.
4. Select any action to execute parsing the uploaded text file.
5. Investigate analysis results of this tex file on the webpage.

### :computer: Using Project's Console Application

Run the program from the command-line with the one argument according the following format:

    <EXECUTABLE> <FILENAME>

In this command, **FILENAME** is a custom text file which should be parsed via the program.

You can see analysis results written by the program to the output **results.log** file.

---

## :whale: Run via Docker

1. Run the **Create-DevCert-HTTPS.ps1** to generate a certificate for this application.
2. Build app's Docker image via **Execute-DockerBuild.ps1** script.
3. Run the app from a new container:
   - Use **Execute-DockerRun-AppWeb.ps1** script to launch the web application.
   - Use **Execute-DockerRun.ps1** script to investigate app's Docker container.

---

## :wrench: Build Source Code

Use **.NET 6 SDK** to build this project from source code.

---

## :email: Contribute the Project

[You can contact me using any contacts from my profile page](https://github.com/dar920910#speech_balloon-how-can-you-contact-with-me-)
