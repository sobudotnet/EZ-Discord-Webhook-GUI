## You can download the exe or build it yourself! its really simple.


## Key features
- Send plain-text messages to a Discord webhook (HTTP/HTTPS).
- Header customization: edit the title text and pick a color.
- Select or download a header icon; app can set the window icon from the selected image.
- Settings persisted to `%AppData%\sinc\settings.xml` and icon stored as `icon.png`.
- Basic validation and user-friendly error messages.

## What you can do with the app
- Enter a Discord webhook URL (full URL starting with `https://`) and a message, then click `Send` (or press Enter).
- Edit the header title using the text box in the header area and apply the change with the `Apply` button.
- Pick a title color with the `Color` button.
- Click the header icon to load a custom image; the app saves the image to the settings folder and applies it to the UI and window icon.

## Build and run
1. Clone the repository.
2. Open the solution in Visual Studio:
   - __File > Open > Project/Solution__ and select the solution file.
3. Ensure the project is targeting `.NET Framework 4.7.2` (confirmed in `App.config`).
   - To change or confirm: __Project > Properties > Application > Target framework__.
4. Build and run:
   - __Build > Build Solution__
   - __Debug > Start Debugging__ or __Debug > Start Without Debugging__.

Alternatively, build from the command line:
- msbuild: `msbuild YourSolution.sln /p:Configuration=Release`

## Configuration & files
- Settings folder: `%AppData%\sinc`
  - `settings.xml` — serialized `AppSettings` object (title text, color ARGB, image file path).
  - `icon.png` — header image saved by the app.
- The app reads `settings.xml` at startup and writes updates when the user changes the title, color, or icon.

## Usage notes & troubleshooting
- Webhook URL must be a valid HTTP/HTTPS URI. The app validates and shows a warning for invalid input.
- If the message is empty, the app asks for confirmation before sending.
- If image files fail to load, messages are shown and the app falls back to defaults.
- Network failures when sending or downloading images will be reported via dialogs.

## Contributing
- Open a pull request with a clear description of the change.
- Keep UI changes consistent with the existing design and ensure behavior is preserved across settings load/save.

## License
- GNU
