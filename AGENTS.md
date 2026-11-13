# QPlanner – instructions for AI assistants

QPlanner is a quarter-planning website. Teams split a quarter into sprints, give each task an owner,
and track what is done, in progress or blocked. It is a high school web-programming project
(ASP.NET Core Razor Pages, HTML, CSS, Bootstrap), so the code must stay simple and easy for a
student to read and explain.

## Project rules (must follow)

1. **No JavaScript.** Do not add `<script>` tags, JS files, or Bootstrap JS components (collapse,
   modal, dropdown, JS tabs). Tabs are links with a `?tab=` query string, handled in C#.
2. **No styling inside pages.** No `style="..."` attributes and no `<style>` blocks in any `.cshtml`
   file. All design goes in `wwwroot/css/site.css`, together with Bootstrap classes.
3. **One stylesheet.** `wwwroot/css/site.css` is the only custom CSS file. Do not add scoped CSS
   (`*.cshtml.css`) or more CSS files.
4. **Every page is its own `.cshtml` file**, and every form lives on its own page.
5. **The site is in English.**
6. **Keep the code simple.** Use plain C#, LINQ and Razor. Do not add new frameworks or libraries
   unless the user asks. A short comment is fine where it helps a student understand the code.

## How to run

```bash
dotnet run          # http://localhost:5217
```

Target framework: `net11.0` (see `QPlanner.csproj`). Only Bootstrap 5.3's CSS is included
(`wwwroot/lib/bootstrap/dist/css`). The project has no JavaScript files at all: Bootstrap JS,
jQuery and the validation scripts were removed on purpose.

## Folder structure

```
Program.cs                      App startup (Razor Pages, static files)
Models/                         Plain data classes
  PlannerTask.cs                A task (Key, Title, Owner, Status, Priority, sprints, ...)
  Sprint.cs                     A 2-week sprint (Number, Start, End, IsCurrent)
  Team.cs                       A team (Name, Lead, Description)
  TeamMember.cs                 A team member (Name, Role, Email, Team, Initials)
Data/
  MockData.cs                   ALL the data of the site + helper methods (no database yet)
Pages/
  _ViewImports.cshtml           Shared usings and tag helpers
  _ViewStart.cshtml             Public pages use _Layout
  Index.cshtml                  Landing page (hero, features, stats, "continue as guest")
  About.cshtml                  "How it works" content page
  Error.cshtml                  Template error page
  Shared/_Layout.cshtml         The only layout. Top navbar (logo, brand, Home, How it works, and on the
                                right "Log in / Sign up" or, once logged in, the username / "Guest" +
                                "View only" badge) + footer. Shows the sidebar on every page once logged
                                in, and always on /Portal pages. Portal pages are NOT linked in the navbar
  Shared/_Sidebar.cshtml        Left sidebar: selected team, portal links, Log out
  Account/
    Login.cshtml                Username + password, links to Register and RecoverPassword,
                                "Continue as guest" button (handler: Guest)
    Register.cshtml             Full sign-up form (see "Forms" below)
    RecoverPassword.cshtml      Username + two security questions, link back to Login
    Logout.cshtml               Deletes the login cookie, redirects to Index
  Portal/
    PortalPageModel.cs          Base class for all portal pages: UserName, IsGuest, TeamName, plus static
                                LoggedInUser(request) / SelectedTeam(request) used by the layout
    QuarterPageModel.cs         Base class for Current Q / Next Q (tasks, members, sprints, Tab)
    _QuarterTabs.cshtml         Partial view shared by CurrentQuarter and NextQuarter
    Home.cshtml                 Dashboard: status counts, progress, blocked tasks, who works on what
    CurrentQuarter.cshtml       Tab "list" (task list) and tab "plan" (members x sprints table)
    NextQuarter.cshtml          Same as CurrentQuarter, for the next quarter
    AllTasks.cshtml             All open (not done) tasks, grouped by quarter
    Team.cshtml                 Team members cards + table of all teams
    Settings.cshtml             Tab "user" (details, change password) and tab "team" (choose team)
wwwroot/
  css/site.css                  The only stylesheet
  images/logo.svg               Logo (navbar, auth pages, favicon)
  images/hero.svg               Landing page illustration
```

## Data model

All data lives in `Data/MockData.cs` as static lists. There is no database yet.

| Class | Fields | Notes |
|---|---|---|
| `PlannerTask` | `Key` (e.g. `WEB-101`), `Title`, `Description`, `Team`, `Quarter` (e.g. `"Q4 2026"`), `Owner` (member name), `Status`, `Priority`, `StartSprint`, `EndSprint` (1–6) | Computed: `IsDone`, `Weeks` (2 per sprint), `SprintRange`, `StatusClass`, `PriorityClass` |
| `Sprint` | `Number`, `Start`, `End` | Computed: `Name` (`S1`), `Dates`, `IsCurrent` (today is inside the sprint) |
| `Team` | `Name`, `Lead`, `Description` | |
| `TeamMember` | `Name`, `Role`, `Email`, `Team` | Computed: `Initials` |

- **Allowed status values:** `Not started`, `In progress`, `Blocked`, `Done`.
- **Allowed priority values:** `High`, `Medium`, `Low`.
- Tasks link to teams and members **by name** (`Team`, `Owner` are strings).
- **Quarters:** `MockData.CurrentQuarter = "Q4 2026"`, `MockData.NextQuarter = "Q1 2027"`.
  `SprintsFor(quarter)` creates 6 sprints of 14 days. Q4 2026 starts 2026-10-01, and Q1 2027
  starts 2027-01-03.
- **Rule:** one member has at most one task in a given sprint. The sprint table
  (`QuarterPageModel.TaskAt`) shows only the first match.
- **Key prefixes by team:** Web Team `WEB-1xx`, Mobile Team `MOB-2xx`, Data Team `DATA-3xx`.
- **Security questions:** `MockData.SecurityQuestions` (used by Register and RecoverPassword).

Helper methods in `MockData`: `FindTeam`, `MembersOf`, `TasksFor(team, quarter)`,
`OpenTasksFor(team)`, `SprintsFor(quarter)`.

## Login, guest and team selection (current behavior)

There is no real authentication yet. Two cookies are used (names in `PortalPageModel`):

- `QPlannerUser`: set by Login (any username and password are accepted), or set to `Guest` by
  the guest button. If the cookie is missing, the portal treats the visitor as `Guest`.
  Portal pages are only linked from the sidebar (reached after Login or "Continue as guest"),
  but they are not locked: opening a portal URL directly works in guest mode.
  `IsGuest` means view only. For example, the change-password form is disabled.
- Logged in (the cookie exists, including `Guest`): the top navbar shows the username instead of
  Log in / Sign up, and the sidebar is shown on every page. The username appears only in the
  top navbar, not in the sidebar.
- `QPlannerTeam`: set by Settings → Team. If it is missing, the first team is used.
  Every portal page shows only the selected team's data.

Register and RecoverPassword check the input (passwords match, two different questions) but do
not save anything. Register redirects to `Login?registered=true`.

## Forms

- **Login:** Username, Password, submit, link to Register, link to RecoverPassword, guest button.
- **Register:** Username, Password, Confirm password, First name, Last name, City, Phone, Email,
  Date of birth, Gender (radio buttons), two security questions (select) with an answer for each,
  Submit and Reset buttons, and a link back to Login.
- **RecoverPassword:** Username, two security questions (select) with answers, submit, and a
  link back to Login.
- **Settings:** change password (Current, New, Confirm) and team choice (radio buttons).

The pages use `[BindProperty]` with `asp-for`, plus the HTML `required` attribute for browser
validation. Server checks add errors to `ModelState`. The validation summary is rendered only
when `ModelState` is invalid, because the empty summary adds an inline `style`.

## Design system (`wwwroot/css/site.css`)

CSS variables in `:root`:

| Variable | Color | Used for |
|---|---|---|
| `--qp-navy` / `--qp-navy-dark` | `#17324d` / `#0f2336` | navbar, sidebar, footer, table headers |
| `--qp-blue` / `--qp-blue-soft` | `#2f4bd8` / `#e6eafc` | primary buttons, links, keys, "In progress" |
| `--qp-amber` / `--qp-amber-soft` | `#f2b705` / `#fff3c4` | highlights, current sprint, "Medium" |
| `--qp-green` / `--qp-green-soft` | `#1f8a4c` / `#dcf3e5` | "Done", progress bar |
| `--qp-red` / `--qp-red-soft` | `#c62f3c` / `#fbe1e3` | "Blocked", "High" |
| `--qp-gray` / `--qp-gray-soft` | `#5b6472` / `#eceef2` | secondary text, "Not started", "Low" |
| `--qp-line`, `--qp-bg`, `--qp-ink` | | borders, page background, text |

All custom classes start with `qp-`. The main groups:

- **Layout:** `qp-navbar`, `qp-brand`, `qp-logo`, `qp-footer`, `qp-sidebar`, `qp-content`
- **Landing:** `qp-hero*`, `qp-feature-card`, `qp-band*`, `qp-step-number`
- **Auth pages:** `qp-auth-page`, `qp-auth-card` (`qp-auth-card-wide` for Register), `qp-auth-title`, `qp-auth-links`, `qp-form-section`
- **Portal:** `qp-page-header`, `qp-page-title`, `qp-section-title`, `qp-stat*`, `qp-widget*`, `qp-progress`, `qp-totals`, `qp-table`
- **Tabs:** `qp-tabs` (Bootstrap `nav-tabs` with links) plus `qp-tab-panel`
- **Badges:** `qp-key` (task key), `status-not-started|in-progress|blocked|done`, `priority-high|medium|low`
  (these come from `PlannerTask.StatusClass` and `PriorityClass`)
- **Quarter list:** `qp-task-row`, `qp-task-title`, `qp-task-tags`, `qp-task-desc`, `qp-task-when`, `is-done`
- **Sprint table:** `qp-plan-table`, `qp-plan-card`, `qp-plan-free`, `sprint-now`, `qp-legend`
- **Team and settings:** `qp-member-card`, `qp-avatar`, `qp-choice-card`

Progress bars use the HTML `<progress>` element, because a Bootstrap progress bar would need an
inline `style="width:..."`. Font: system font stack. Rounded cards (12–16px), light borders.

## Adding a page

1. Create `Pages/<Folder>/<Name>.cshtml` and `<Name>.cshtml.cs`.
2. Portal pages inherit `PortalPageModel`, so they get the user, guest flag and team.
3. Add a link to the sidebar in `Pages/Shared/_Sidebar.cshtml`. Only public pages (landing,
   About, account pages) go in the top navbar in `_Layout.cshtml`.
4. Put any new styles in `site.css` with a `qp-` prefix.

## Planned next steps (guidance)

### 1. Add a database

- Use **Entity Framework Core with SQLite** (simple, file-based): `Microsoft.EntityFrameworkCore.Sqlite`.
- Create `Data/AppDbContext.cs` with a `DbSet` for `PlannerTask`, `Team`, `TeamMember`,
  `Sprint` (optional, because sprints can stay calculated) and a new `User` class.
- Add an `int Id` primary key to every model. Consider replacing the name links
  (`Team`, `Owner`) with `TeamId` and `OwnerId`, and update the pages that compare by name.
- Seed the database from the current `MockData` lists, so the site looks the same afterwards.
- Replace each `MockData.X(...)` call in the page models with a query on the injected
  `AppDbContext` (constructor injection). Keep `MockData` only as seed data, or delete it.
- **`User`:** Username, PasswordHash (never store plain passwords, use
  `PasswordHasher<User>` from ASP.NET Core Identity), first and last name, City, Phone, Email,
  BirthDate, Gender, Question1, Answer1Hash, Question2, Answer2Hash, TeamId.
- Then make Register save users, Login check the password, RecoverPassword check the answers,
  and Settings save the new password and team.
- For real login, use cookie authentication (`AddAuthentication().AddCookie()`) and
  `[Authorize]` on portal pages instead of the `QPlannerUser` cookie.

### 2. Create and edit tasks from the website

- Add a separate page, `Pages/Portal/TaskCreate.cshtml` (and later `TaskEdit.cshtml`), each with
  its own form. Do not put the form inside the list page.
- **Fields:** Key, Title, Description, Quarter (select: current or next), Owner (select from team
  members), Status (select), Priority (select), StartSprint and EndSprint (select 1–6).
- **Server checks:** the key is unique, Start ≤ End, and the owner has no other task in those sprints.
- **Guests must not create or edit:** hide the buttons when `IsGuest`, and also refuse in `OnPost`.
- Add a "New task" button (a link, not JS) on CurrentQuarter, NextQuarter and AllTasks, and make
  each task key link to the edit page.
- Until the database exists, new tasks can be added to `MockData.Tasks` in memory, but they
  disappear when the app restarts.

## Things to keep working

- The top navbar on every page includes the logo, the brand, and links to Home, How it works,
  Log in and Sign up.
- Portal pages are reached only through Login or "Continue as guest" (no portal links in the top navbar).
- Login links to Register and RecoverPassword. RecoverPassword and Register link back to Login.
- At least 10 separate pages.
- No JavaScript, no inline styles, a single CSS file.
