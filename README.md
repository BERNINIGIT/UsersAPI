# UsersAPI

How to run the project:
Simply clone the solution and run it.

The project refreshes users data everytime it runs again. So when run, migrations are run as well inserting these users:

Login = "bernini",
Password = "B3rn1n1",
Role = "admin",
UsdBalance = 50003.4M

Login = "admin1",
Password = "admin1",
Role = "admin",
UsdBalance = 57703.4M

Login = "guest1",
Password = "g35t",
Role = "user",
UsdBalance = 105.1M
Login = "guest2",
Password = "g35t",
Role = "user",
UsdBalance = 105.1M

Login = "guest3",
Password = "g35t",
Role = "user",
UsdBalance = 105.1M

How to use the project:
You can use any of those users to test.

There are 3 endpoints in the project. You can use this postman collection to do this easily: https://www.getpostman.com/collections/f0575b75f721840d434f

POST: https://localhost:44345/api/user

Running this ulr with post will do the login. Use this payload to test. 

{
    "Login": "admin1",
    "Password": "admin1"
}

The response will be like this:

{
    "token": {
        "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkbWluMSIsInJvbGUiOiJhZG1pbiIsIm5iZiI6MTY0OTkyMjY2MywiZXhwIjoxNjQ5OTIzMjYzLCJpYXQiOjE2NDk5MjI2NjN9.90KfvrzZfggfr8T1dXpbg2GBxp8z6LMPORm7XSTG-1I",
        "refreshToken": null
    },
    "userInfo": {
        "login": "admin1",
        "role": "admin",
        "usdBalance": 57703.4
    }
}

After a successful login, user info is returned along with a token, use this token as a bearer token to get access to the put and delete methods.

PUT: https://localhost:44345/api/user

Using the token from the login method as a bearer token, use put as http verb along with this payload to update balance

{
    "Balance" : "123.4"
}

DELETE: https://localhost:44345/api/user

Using the token from the login method as bearer token, use delete http verb along with this payload to delete a user, note only bernini and admin1 users can do this
Replace "guest1" with any other user you want to delete.

{
    "Login": "guest1"
}
              
