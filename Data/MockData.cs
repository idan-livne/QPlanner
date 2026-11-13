using QPlanner.Models;

namespace QPlanner.Data
{
    // Fake data used until the site is connected to a database.
    public static class MockData
    {
        public const string CurrentQuarter = "Q4 2026";
        public const string NextQuarter = "Q1 2027";

        public static readonly List<Team> Teams = new List<Team>
        {
            new Team { Name = "Web Team", Lead = "Dana Cohen", Description = "Builds and maintains the QPlanner website and the admin portal." },
            new Team { Name = "Mobile Team", Lead = "Yoni Levi", Description = "Builds the QPlanner apps for iPhone and Android." },
            new Team { Name = "Data Team", Lead = "Maya Shapiro", Description = "Owns the reports, the dashboards and the data pipeline." }
        };

        public static readonly List<TeamMember> Members = new List<TeamMember>
        {
            new TeamMember { Name = "Dana Cohen", Role = "Team Lead", Email = "dana@qplanner.dev", Team = "Web Team" },
            new TeamMember { Name = "Noam Katz", Role = "Frontend Developer", Email = "noam@qplanner.dev", Team = "Web Team" },
            new TeamMember { Name = "Shira Golan", Role = "Backend Developer", Email = "shira@qplanner.dev", Team = "Web Team" },
            new TeamMember { Name = "Omer Ben-David", Role = "QA Engineer", Email = "omer@qplanner.dev", Team = "Web Team" },

            new TeamMember { Name = "Yoni Levi", Role = "Team Lead", Email = "yoni@qplanner.dev", Team = "Mobile Team" },
            new TeamMember { Name = "Tamar Peretz", Role = "iOS Developer", Email = "tamar@qplanner.dev", Team = "Mobile Team" },
            new TeamMember { Name = "Eitan Mizrahi", Role = "Android Developer", Email = "eitan@qplanner.dev", Team = "Mobile Team" },

            new TeamMember { Name = "Maya Shapiro", Role = "Team Lead", Email = "maya@qplanner.dev", Team = "Data Team" },
            new TeamMember { Name = "Lior Azulay", Role = "Data Engineer", Email = "lior@qplanner.dev", Team = "Data Team" },
            new TeamMember { Name = "Roni Friedman", Role = "Data Analyst", Email = "roni@qplanner.dev", Team = "Data Team" }
        };

        public static readonly List<PlannerTask> Tasks = new List<PlannerTask>
        {
            // Web Team - Q4 2026
            new PlannerTask { Key = "WEB-101", Title = "Quarter kickoff and roadmap review", Owner = "Dana Cohen", Status = "Done", Priority = "Medium", StartSprint = 1, EndSprint = 1, Team = "Web Team", Quarter = "Q4 2026", Description = "Agree on the goals for the quarter and split the work between the team members." },
            new PlannerTask { Key = "WEB-104", Title = "Accessibility audit", Owner = "Dana Cohen", Status = "Done", Priority = "High", StartSprint = 2, EndSprint = 3, Team = "Web Team", Quarter = "Q4 2026", Description = "Check every page with a screen reader and fix contrast problems." },
            new PlannerTask { Key = "WEB-110", Title = "Team onboarding guide", Owner = "Dana Cohen", Status = "In progress", Priority = "Low", StartSprint = 4, EndSprint = 6, Team = "Web Team", Quarter = "Q4 2026", Description = "Write a short guide that helps new developers set up the project on their first day." },
            new PlannerTask { Key = "WEB-102", Title = "New landing page design", Owner = "Noam Katz", Status = "Done", Priority = "High", StartSprint = 1, EndSprint = 2, Team = "Web Team", Quarter = "Q4 2026", Description = "A fresh hero section, clear sign-up buttons and new illustrations." },
            new PlannerTask { Key = "WEB-105", Title = "Dark mode for the portal", Owner = "Noam Katz", Status = "In progress", Priority = "Medium", StartSprint = 3, EndSprint = 4, Team = "Web Team", Quarter = "Q4 2026", Description = "Add a dark color theme that users can switch on from the settings page." },
            new PlannerTask { Key = "WEB-111", Title = "Mobile-friendly tables", Owner = "Noam Katz", Status = "Not started", Priority = "Medium", StartSprint = 5, EndSprint = 6, Team = "Web Team", Quarter = "Q4 2026", Description = "Make the task and sprint tables easy to read on a phone." },
            new PlannerTask { Key = "WEB-103", Title = "Login and registration API", Owner = "Shira Golan", Status = "Done", Priority = "High", StartSprint = 1, EndSprint = 3, Team = "Web Team", Quarter = "Q4 2026", Description = "Server code that checks usernames and passwords and creates new users." },
            new PlannerTask { Key = "WEB-106", Title = "Password recovery flow", Owner = "Shira Golan", Status = "In progress", Priority = "High", StartSprint = 4, EndSprint = 5, Team = "Web Team", Quarter = "Q4 2026", Description = "Let users reset their password by answering their two security questions." },
            new PlannerTask { Key = "WEB-112", Title = "Email notifications", Owner = "Shira Golan", Status = "Not started", Priority = "Low", StartSprint = 6, EndSprint = 6, Team = "Web Team", Quarter = "Q4 2026", Description = "Send an email when a task is assigned to you." },
            new PlannerTask { Key = "WEB-107", Title = "Automated UI tests", Owner = "Omer Ben-David", Status = "Done", Priority = "Medium", StartSprint = 1, EndSprint = 2, Team = "Web Team", Quarter = "Q4 2026", Description = "Tests that open the site and click through the main pages." },
            new PlannerTask { Key = "WEB-108", Title = "Load testing for the task list", Owner = "Omer Ben-David", Status = "Blocked", Priority = "High", StartSprint = 3, EndSprint = 4, Team = "Web Team", Quarter = "Q4 2026", Description = "Blocked: waiting for the new test server." },
            new PlannerTask { Key = "WEB-109", Title = "Bug bash before release", Owner = "Omer Ben-David", Status = "Not started", Priority = "Medium", StartSprint = 5, EndSprint = 6, Team = "Web Team", Quarter = "Q4 2026", Description = "The whole team spends a day looking for bugs before the release." },

            // Web Team - Q1 2027
            new PlannerTask { Key = "WEB-120", Title = "Plan Q2 hiring", Owner = "Dana Cohen", Status = "Not started", Priority = "Low", StartSprint = 1, EndSprint = 2, Team = "Web Team", Quarter = "Q1 2027", Description = "Decide which roles the team needs next quarter." },
            new PlannerTask { Key = "WEB-124", Title = "Customer feedback sessions", Owner = "Dana Cohen", Status = "Not started", Priority = "Medium", StartSprint = 3, EndSprint = 6, Team = "Web Team", Quarter = "Q1 2027", Description = "Meet five teams that use QPlanner and collect their ideas." },
            new PlannerTask { Key = "WEB-121", Title = "Drag and drop for the sprint table", Owner = "Noam Katz", Status = "Not started", Priority = "High", StartSprint = 1, EndSprint = 3, Team = "Web Team", Quarter = "Q1 2027", Description = "Move tasks between sprints and team members with the mouse." },
            new PlannerTask { Key = "WEB-125", Title = "Task search and filters", Owner = "Noam Katz", Status = "Not started", Priority = "Medium", StartSprint = 4, EndSprint = 6, Team = "Web Team", Quarter = "Q1 2027", Description = "Search tasks by name and filter them by status or owner." },
            new PlannerTask { Key = "WEB-122", Title = "Connect the site to a database", Owner = "Shira Golan", Status = "Not started", Priority = "High", StartSprint = 1, EndSprint = 4, Team = "Web Team", Quarter = "Q1 2027", Description = "Replace the mocked data with real data saved in a database." },
            new PlannerTask { Key = "WEB-126", Title = "Create and edit tasks", Owner = "Shira Golan", Status = "Not started", Priority = "High", StartSprint = 5, EndSprint = 6, Team = "Web Team", Quarter = "Q1 2027", Description = "Forms for adding new tasks and changing existing ones." },
            new PlannerTask { Key = "WEB-123", Title = "Test plan for the database move", Owner = "Omer Ben-David", Status = "Not started", Priority = "Medium", StartSprint = 1, EndSprint = 2, Team = "Web Team", Quarter = "Q1 2027", Description = "List what to check so no data is lost during the move." },
            new PlannerTask { Key = "WEB-127", Title = "Regression tests for task editing", Owner = "Omer Ben-David", Status = "Not started", Priority = "Medium", StartSprint = 5, EndSprint = 6, Team = "Web Team", Quarter = "Q1 2027", Description = "Make sure editing tasks does not break older features." },

            // Mobile Team - Q4 2026
            new PlannerTask { Key = "MOB-201", Title = "App store release 2.0", Owner = "Yoni Levi", Status = "Done", Priority = "High", StartSprint = 1, EndSprint = 2, Team = "Mobile Team", Quarter = "Q4 2026", Description = "Publish version 2.0 of the app on both stores." },
            new PlannerTask { Key = "MOB-205", Title = "Push notifications", Owner = "Yoni Levi", Status = "In progress", Priority = "High", StartSprint = 3, EndSprint = 5, Team = "Mobile Team", Quarter = "Q4 2026", Description = "Notify users on their phone when a task changes." },
            new PlannerTask { Key = "MOB-202", Title = "iPhone widget for today's tasks", Owner = "Tamar Peretz", Status = "Done", Priority = "Medium", StartSprint = 1, EndSprint = 3, Team = "Mobile Team", Quarter = "Q4 2026", Description = "A home screen widget that shows the tasks due today." },
            new PlannerTask { Key = "MOB-206", Title = "Offline mode for iPhone", Owner = "Tamar Peretz", Status = "In progress", Priority = "Medium", StartSprint = 4, EndSprint = 6, Team = "Mobile Team", Quarter = "Q4 2026", Description = "View tasks without an internet connection." },
            new PlannerTask { Key = "MOB-203", Title = "Android login screen", Owner = "Eitan Mizrahi", Status = "Done", Priority = "High", StartSprint = 1, EndSprint = 2, Team = "Mobile Team", Quarter = "Q4 2026", Description = "A new login screen that matches the website design." },
            new PlannerTask { Key = "MOB-204", Title = "Android crash fixes", Owner = "Eitan Mizrahi", Status = "Done", Priority = "High", StartSprint = 3, EndSprint = 3, Team = "Mobile Team", Quarter = "Q4 2026", Description = "Fix the three most common crashes from the store reports." },
            new PlannerTask { Key = "MOB-207", Title = "Offline mode for Android", Owner = "Eitan Mizrahi", Status = "Blocked", Priority = "Medium", StartSprint = 4, EndSprint = 6, Team = "Mobile Team", Quarter = "Q4 2026", Description = "Blocked: waiting for the iPhone version to finish the shared design." },

            // Mobile Team - Q1 2027
            new PlannerTask { Key = "MOB-210", Title = "Tablet layout", Owner = "Yoni Levi", Status = "Not started", Priority = "Medium", StartSprint = 1, EndSprint = 3, Team = "Mobile Team", Quarter = "Q1 2027", Description = "Use the extra space on tablets to show the sprint table." },
            new PlannerTask { Key = "MOB-211", Title = "Calendar sync", Owner = "Tamar Peretz", Status = "Not started", Priority = "High", StartSprint = 1, EndSprint = 4, Team = "Mobile Team", Quarter = "Q1 2027", Description = "Show sprint dates in the phone's calendar." },
            new PlannerTask { Key = "MOB-212", Title = "Android widget", Owner = "Eitan Mizrahi", Status = "Not started", Priority = "Low", StartSprint = 2, EndSprint = 4, Team = "Mobile Team", Quarter = "Q1 2027", Description = "The Android version of the today's tasks widget." },

            // Data Team - Q4 2026
            new PlannerTask { Key = "DATA-301", Title = "Weekly progress report", Owner = "Maya Shapiro", Status = "Done", Priority = "High", StartSprint = 1, EndSprint = 2, Team = "Data Team", Quarter = "Q4 2026", Description = "An automatic report sent every Sunday to all team leads." },
            new PlannerTask { Key = "DATA-304", Title = "Quarter summary dashboard", Owner = "Maya Shapiro", Status = "In progress", Priority = "High", StartSprint = 3, EndSprint = 6, Team = "Data Team", Quarter = "Q4 2026", Description = "One page that shows how every team is doing this quarter." },
            new PlannerTask { Key = "DATA-302", Title = "Move the data pipeline to the cloud", Owner = "Lior Azulay", Status = "In progress", Priority = "High", StartSprint = 1, EndSprint = 4, Team = "Data Team", Quarter = "Q4 2026", Description = "Run the nightly data jobs on cloud servers instead of the office server." },
            new PlannerTask { Key = "DATA-305", Title = "Nightly backup job", Owner = "Lior Azulay", Status = "Not started", Priority = "Medium", StartSprint = 5, EndSprint = 6, Team = "Data Team", Quarter = "Q4 2026", Description = "Back up all planning data every night." },
            new PlannerTask { Key = "DATA-303", Title = "Team velocity chart", Owner = "Roni Friedman", Status = "Done", Priority = "Medium", StartSprint = 2, EndSprint = 3, Team = "Data Team", Quarter = "Q4 2026", Description = "A chart of how many tasks each team finishes per sprint." },
            new PlannerTask { Key = "DATA-306", Title = "Survey results analysis", Owner = "Roni Friedman", Status = "Blocked", Priority = "Low", StartSprint = 4, EndSprint = 5, Team = "Data Team", Quarter = "Q4 2026", Description = "Blocked: the survey closes at the end of the month." },

            // Data Team - Q1 2027
            new PlannerTask { Key = "DATA-310", Title = "Forecast next quarter's workload", Owner = "Maya Shapiro", Status = "Not started", Priority = "Medium", StartSprint = 1, EndSprint = 3, Team = "Data Team", Quarter = "Q1 2027", Description = "Use past sprints to guess how much work fits in a quarter." },
            new PlannerTask { Key = "DATA-311", Title = "Data quality checks", Owner = "Lior Azulay", Status = "Not started", Priority = "High", StartSprint = 2, EndSprint = 5, Team = "Data Team", Quarter = "Q1 2027", Description = "Find and report missing or wrong data automatically." },
            new PlannerTask { Key = "DATA-312", Title = "Export reports to PDF", Owner = "Roni Friedman", Status = "Not started", Priority = "Low", StartSprint = 1, EndSprint = 2, Team = "Data Team", Quarter = "Q1 2027", Description = "A button that saves any report as a PDF file." }
        };

        public static readonly List<string> SecurityQuestions = new List<string>
        {
            "What was the name of your first pet?",
            "In which city were you born?",
            "What is the name of your elementary school?",
            "What is your favorite book?",
            "What was your childhood nickname?"
        };

        public static Team FindTeam(string name)
        {
            return Teams.FirstOrDefault(t => t.Name == name) ?? Teams[0];
        }

        public static List<TeamMember> MembersOf(string team)
        {
            return Members.Where(m => m.Team == team).ToList();
        }

        public static List<PlannerTask> TasksFor(string team, string quarter)
        {
            return Tasks.Where(t => t.Team == team && t.Quarter == quarter).OrderBy(t => t.StartSprint).ToList();
        }

        public static List<PlannerTask> OpenTasksFor(string team)
        {
            return Tasks.Where(t => t.Team == team && !t.IsDone).ToList();
        }

        // Each quarter has 6 sprints of two weeks.
        public static List<Sprint> SprintsFor(string quarter)
        {
            DateTime firstDay = quarter == CurrentQuarter ? new DateTime(2026, 10, 1) : new DateTime(2027, 1, 3);
            var sprints = new List<Sprint>();
            for (int i = 0; i < 6; i++)
            {
                sprints.Add(new Sprint
                {
                    Number = i + 1,
                    Start = firstDay.AddDays(i * 14),
                    End = firstDay.AddDays(i * 14 + 13)
                });
            }
            return sprints;
        }
    }
}
