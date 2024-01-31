# com.planetarium.v8.ui

## Welcome!
Welcome to the **com.planetarium.v8.ui** repository.

**com.planetarium.v8.ui** is a Unity package designed for creating dynamic and responsive user interfaces in Unity games. This package allows developers to efficiently design UI components using JSON metadata, which are then dynamically rendered within the game.

## Getting Started
To get started with **com.planetarium.v8.ui**:

- Visit our [Documentation](https://github.com/planetarium/com.planetarium.v8.ui) for detailed package usage and API information.
- Explore the [com.planetarium.v8.ui](https://github.com/planetarium/com.planetarium.v8.ui/tree/development/com.planetarium.v8.ui) folder, which contains all scripts and assets for the UI package.
- Check out the Unity Test Scenes in the [v8.ui.test](https://github.com/planetarium/com.planetarium.v8.ui/tree/development/v8.ui.test) folder for examples of how to implement the UI elements in a Unity scene.
- Use the [UI Viewer](https://fictional-dollop-evegrqy.pages.github.io/) in the [docs](https://github.com/planetarium/com.planetarium.v8.ui/tree/development/docs) to load and preview your UI designs from JSON files.

## Development
This repository is organized into multiple components:
```
    .
    ├── com.planetarium.v8.ui        # The core UI SDK unity package (source + tests)
    ├── v8.ui.test                   # Unity Test Scenes and the UIViewer for JSON UI design preview.
    └── docs                         # UIViewer build files for web deployment.
```

## Installation
To install the [com.planetarium.v8.ui](https://github.com/planetarium/com.planetarium.v8.ui) package, you need to use the Unity Package Manager with a Git URL. Here's how you can do it:

1. Open the Unity Editor and go to Window > Package Manager.
2. In the Package Manager window, click the + button and select `Install package from git URL`.
3. Enter the following URL and click `Add` to add the package
    ```
    https://github.com/planetarium/com.planetarium.v8.ui.git#development?path=com.planetarium.v8.ui
    ```
4. Once added, the package will be displayed in the Package Manager of your Unity Editor.

This method allows you to directly install the [com.planetarium.v8.ui](https://github.com/planetarium/com.planetarium.v8.ui) package in your Unity project, making it easier to manage and update the package.

## Requirements
This version of Unity NetCode is compatible with the following versions of the Unity Editor:
- 2023.2.4 and later (recommended)

This package is based on [Unity UI](https://docs.unity3d.com/kr/2023.2/Manual/com.unity.ugui.html). Therefore, to use this package, you need to have knowledge of **Unity UI**.

