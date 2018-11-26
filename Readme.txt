There is no authentication or authorization present in this project.  I also disabled CORS (see Startup.cs).

I have added a few Postman scripts in a solutions folder for testing purposes.

There was no requirement for Unit Tests, but there is always room for them so I made a few basic tests.  That
should become far more robust.

I set up the xml comments in support of both intellisense and a potential Swagger implementation.

I did not add logging, but did note multiple places where I would log some information.  Just samples of my thoughts
and by no means meant to be an exhaustive example set.

The data is all in memory and does not actually persist.

The web UI is very, very basic, but gives my idea for a set of checkboxes that the user can flip on and off and have them persist.
	I defaulted the web interface to work with just a single user.  There isn't any login functionality, but could add a drop down 
	to select which user to update preferences on, but that would be more administrative in nature.

Code SandBox URL  https://codesandbox.io/s/7zypw3pkl0


Questions I would normally ask, but I just made assumptions due to the holidays:
1) What would the standard preferences default to?  I assumed true, due to work on similar projects in the past.
2) Are there likely to be many more preferences of this nature?
3) Are there already preferences of a different nature in the actual data storage?
4) Is there a need for admin functionality to adjust these preferences on behalf of the users themselves?

Most of my assumptions were based on the nature of the assignment being to develop an api quickly.

I left comments in the code to show my thought processes.  Typically I leave a few comments, but they are of a Meta nature.



I build the web UI in React.  I don't have much true experience using it (as I noted during our in phone interview), but I 
wanted to demonstrate my ability to adapt as needed.  Thanks for the opportunity.