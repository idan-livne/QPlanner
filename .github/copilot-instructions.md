# Copilot instructions

The full project guide is in [AGENTS.md](../AGENTS.md) at the repository root. Read it before
making changes. It covers the folder structure, data model, design system and planned next steps.

The most important rules:

- ASP.NET Core Razor Pages project. Keep the code simple, because it is a high school project.
- No JavaScript at all. Tabs are links with `?tab=`.
- No `style` attributes or `<style>` blocks in pages. All styling goes in `wwwroot/css/site.css`
  (the only CSS file) plus Bootstrap 5.3 classes. Custom classes use the `qp-` prefix.
- Every page and every form is its own `.cshtml` file.
- The data lives in `Data/MockData.cs` until a database is added.
- The site is in English.
- When you change the structure, data model or design, update `AGENTS.md` too.
