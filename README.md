# TrainingWheels.WebApi

## About TrainingWheels
Training Wheels is an app to gamify adulthood. The basic goal is to accumulate as many points as possible
by entering tasks you've performed, which you can select on the site. Each task has a designated number
of points, so more important or major tasks will give the user a much bigger jump in their rating.
The rating is a score-range-based assessment of what your present level of activity says about your
adulthood. There is also a page for noting personal goals or making notes or TODOs.

## Getting Started

### Database
Clone the repository from github, and open the program. Run the Package Manager Console and perform a 
migration from TrainingWheels.Data. If everything works correctly, this should create the database
and its tables. After that, you will want to run this SQL to give the activity tables their needed contents:
```sql
INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Got 6 - 8 hours of sleep', 1, 50);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Worked out', 1, 20);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Went grocery shopping', 1, 65);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Cooked a meal or reheated precooked leftovers', 1, 15);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Didn''t let the existential dread set in', 1, 1);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Did laundry', 2, 200);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Showered', 2, 33);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Brushed teeth', 2, 15);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Maintained body and/or facial hair', 2, 50);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Cleaned gunk under fingernails', 2, 1);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Paid utilities', 3, 1000);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Made a deposit', 3, 500);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Managed online bank statement', 3, 250);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Paid some debt', 3, 250);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Opened a Swiss bank account', 3, 3500);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Called a family member', 4, 125);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Attended a group activity', 4, 200);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Enjoyed intoxicants responsibly', 4, 63);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Spent time with someone in person', 4, 125);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Met a new dog', 4, 4);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Kept an appointment', 5, 100);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Remembered an important date', 5, 100);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Made it to work on time', 5, 60);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Cleaned a room', 5, 33);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Took out the trash', 5, 100);

INSERT INTO dbo.ActivityEntities (Name, Category, Score)
VALUES('Stared blankly at an organization chart', 5, 0);
```

### Admin setup
Run the API, and use the companion Angular front-end, TrainingWheels.WebAngular, to register a new user.
Using Postman or a similar tool, enter the API's url, followed by '/token', as a post request. Set the
Content-Type as application/x-www-form-urlencoded, and enter the email address you registered (in the Type
"username"), the password, and the grant_type: password. When you submit, you should receive a bearer token
in response.
Now, perform another post, this time with an Authorization header, using "Bearer [your token]" as that
header. In the body, again application/x-www-form-urlencoded, give an Email type, and then the email address
you want as an admin. The url for this post will be the API's url followed by
/api/Account/AddUserToAdmin. After this, if you retrieve a new token, and do a get request at
API's url + /api/ManageUsers a list of users should show, if adding the admin worked.
