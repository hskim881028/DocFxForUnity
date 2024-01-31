# Verse 8 UI

## Overview
[com.planetarium.v8.ui](https://github.com/planetarium/com.planetarium.v8.ui) is a custom UI package for Unity, designed to facilitate the efficient creation and management of user interfaces in Unity games. This package enables developers to dynamically construct UIs within Unity, using JSON metadata as a blueprint. It's tailored for game developers seeking a streamlined and flexible approach to UI development.

## Key Features
- Modular UI Elements: The package includes a variety of modular elements such as images, labels, layouts, and buttons, which can be combined and customized to create diverse UI components.
- Dynamic UI Construction: [com.planetarium.v8.ui](https://github.com/planetarium/com.planetarium.v8.ui) uses JSON metadata to dynamically generate UI elements in Unity. This allows developers to define their UI structure and properties externally and have them realized within the game environment.
- Flexible and Customizable: The package's design is highly customizable, enabling developers to tailor UI components to their specific game's needs.

## JSON Metadata Integration
The use of JSON metadata is a key aspect of [com.planetarium.v8.ui](https://github.com/planetarium/com.planetarium.v8.ui). This integration allows for:

1. **External UI Definition**: Developers can define the UI's layout, appearance, and behavior in JSON files.
2. **Runtime UI Construction**: During the game's runtime, [com.planetarium.v8.ui](https://github.com/planetarium/com.planetarium.v8.ui) interprets these JSON files and constructs the corresponding UI elements within Unity, providing a live and dynamic UI experience.

## Implementation
Incorporating [com.planetarium.v8.ui](https://github.com/planetarium/com.planetarium.v8.ui) into your Unity project is straightforward:

1. Prepare JSON Metadata: Create JSON files defining the desired UI components.
2. Import the Package: Add [com.planetarium.v8.ui](https://github.com/planetarium/com.planetarium.v8.ui) to your Unity project.
3. Construct UI Dynamically: The package will read the JSON metadata and create the UI elements accordingly in your Unity game.

## Conclusion
[com.planetarium.v8.ui](https://github.com/planetarium/com.planetarium.v8.ui) offers an innovative solution for Unity game developers to create and manage their game UIs effectively. Its combination of modular design and dynamic JSON metadata integration provides a powerful tool for building responsive and visually appealing user interfaces, enhancing the overall gaming experience.

Installation
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

