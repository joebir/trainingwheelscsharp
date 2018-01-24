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
and its tables.

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
