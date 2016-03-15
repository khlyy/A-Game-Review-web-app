CREATE TABLE Members 
(
e_mail VARCHAR(50) PRIMARY KEY ,
password INT ,
preferred_game_genre VARCHAR(50),
membership_type VARCHAR(50)
)



CREATE TABLE Normal_Users 
(
e_mail VARCHAR(50) PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50),
date_of_birth SMALLDATETIME ,
age AS (YEAR(CURRENT_TIMESTAMP)-YEAR(date_of_birth)),
FOREIGN KEY (e_mail) REFERENCES Members ON DELETE CASCADE
) 


CREATE TABLE Members_Add_Members 
(
e_mail1 VARCHAR(50) ,
e_mail2 VARCHAR(50) ,
accept BIT,
PRIMARY KEY (e_mail1,e_mail2),
FOREIGN KEY (e_mail1) REFERENCES Normal_Users(e_mail) ON DELETE CASCADE,
FOREIGN KEY (e_mail2) REFERENCES Normal_Users(e_mail) 
)

CREATE TABLE Member_Send_Message_To_Members 
(
message_id INT IDENTITY ,
sender VARCHAR(50),
reciever VARCHAR(50),
date SMALLDATETIME ,
content TEXT,
PRIMARY KEY (message_id),
FOREIGN KEY (sender) REFERENCES Normal_Users ON DELETE CASCADE,
FOREIGN KEY (reciever) REFERENCES Normal_Users
)

CREATE TABLE Development_Teams 
(
e_mail VARCHAR(50) PRIMARY KEY  ,
team_name VARCHAR(50) ,
company VARCHAR(50) ,
formation_date SMALLDATETIME ,
FOREIGN KEY (e_mail) REFERENCES Members ON DELETE CASCADE
)

CREATE TABLE Verified_Reviewers 
(
e_mail VARCHAR(50 ) PRIMARY KEY ,
first_name VARCHAR(50),
last_name VARCHAR(50),
year_of_experience INT ,
FOREIGN KEY (e_mail) REFERENCES Members ON DELETE CASCADE 
)

CREATE TABLE Communities 
(
theme VARCHAR(50) PRIMARY KEY ,
name VARCHAR(50) ,
description  TEXT 
)
  

  CREATE TABLE Members_Join_Communities
  (
  theme VARCHAR (50) ,
  member_id VARCHAR(50),
  PRIMARY KEY (theme,member_id),
  FOREIGN KEY (theme) REFERENCES  Communities ON DELETE CASCADE,
  FOREIGN KEY (member_id) REFERENCES  Members ON DELETE CASCADE
  )

  CREATE TABLE Members_Post_Topic_On_Communities 
  (
  theme VARCHAR(50),
  topic_id INT IDENTITY ,
  title VARCHAR(100) ,
  description TEXT ,
  member_id VARCHAR(50),
  PRIMARY KEY(theme ,topic_id),
  FOREIGN KEY (theme) REFERENCES Communities ON DELETE CASCADE,
  FOREIGN KEY (member_id) REFERENCES  Members ON DELETE CASCADE 
   ) 

   CREATE TABLE Members_Comment_On_Topics
   (
	theme VARCHAR(50),
    topic_id INT  ,
	comment_id INT IDENTITY ,
	content TEXT ,
	date SMALLDATETIME ,
	member_id VARCHAR(50),
	PRIMARY KEY (theme,topic_id,comment_id),
	FOREIGN KEY (theme,topic_id) REFERENCES Members_Post_Topic_On_Communities(theme,topic_id),
	FOREIGN KEY (member_id) REFERENCES Members ON DELETE CASCADE 
	)


	CREATE TABLE Conferences (
	conference_id INT IDENTITY PRIMARY KEY,
	name VARCHAR(50),
	start_date SMALLDATETIME,
	end_date SMALLDATETIME,
	duration AS DATEDIFF(DAY,start_date,end_date),
	venue VARCHAR(100),
	)

	CREATE TABLE Members_Attend_Conferences(
	member_id VARCHAR(50),
	conference_id INT ,
	PRIMARY KEY(member_id,conference_id),
	FOREIGN KEY(member_id) REFERENCES Members ON DELETE CASCADE,
	FOREIGN KEY (conference_id) REFERENCES Conferences ON DELETE CASCADE
	)

	CREATE TABLE Members_Add_Reviews_To_Conferences(
	conference_review_id INT IDENTITY ,
	conference_id INT,
	member_id VARCHAR(50),
	content TEXT,
	date SMALLDATETIME,
	title text,
	PRIMARY KEY(conference_review_id,conference_id),
	FOREIGN KEY(conference_id) references Conferences ON DELETE CASCADE,
	FOREIGN KEY(member_id) references Members ON DELETE CASCADE
	)


	CREATE TABLE Members_Comment_On_Conference_Review(
	
	comment_id INT IDENTITY,
	conference_review_id INT,
	conference_id INT ,
	content TEXT,
	member_id VARCHAR(50),
	PRIMARY KEY (comment_id,conference_review_id,conference_id),
	FOREIGN KEY (conference_review_id,conference_id) REFERENCES Members_Add_Reviews_To_Conferences(conference_review_id,conference_id),
	FOREIGN KEY (member_id) REFERENCES Members ON DELETE CASCADE
	)

	CREATE TABLE Games (
	
	game_ID INT IDENTITY PRIMARY KEY, name VARCHAR(50) ,
	release_date SMALLDATETIME,
	 rating INT ,
	 age_limit INT ,
	 development_team_email VARCHAR(50),
	 release_conference INT ,
	 FOREIGN KEY (development_team_email) REFERENCES Development_Teams ON DELETE CASCADE,
	 FOREIGN KEY (release_conference) REFERENCES Conferences ON DELETE CASCADE 
	)
	
	CREATE TABLE Screenshots(
	screenshot_id INT IDENTITY,
	game_id INT ,
	description TEXT,
	date SMALLDATETIME,
	PRIMARY KEY(screenshot_id,game_id),
	FOREIGN KEY(game_id) REFERENCES Games ON DELETE CASCADE 	
	)

	CREATE TABLE Sports (
	game INT PRIMARY KEY   ,
	type1 VARCHAR(50),
	FOREIGN KEY (game) REFERENCES Games ON DELETE CASCADE 
	)
	

	
	
	CREATE TABLE Strategies(
	game_id INT PRIMARY KEY,
	real_time  BIT ,
	FOREIGN KEY (game_id) references Games ON DELETE CASCADE
	)


	create table Videos (
	video_id int identity, 
	game_id int , 
	description text,
	 date  smalldatetime,
	 primary key(video_id,game_id),
	 foreign key (game_id)references Games ON DELETE CASCADE  
	
	)

	create table Actions (
	game_id int primary key,
	sub_genre varchar(50),
	foreign key (game_id) references Games ON DELETE CASCADE
	)


	create table  RPG (
	game_id int primary key ,
	story_line bit,
	pvp bit,
	foreign key (game_id) references Games ON DELETE CASCADE
	)
	

	CREATE TABLE Games_Rated_By_Members (
	rate_id int identity ,
	game_id int ,
	member_email varchar(50),
	graphics int ,
	level_design int ,
	interactivity int ,
	uniqueness int ,
	average_rate  as ((uniqueness+graphics+interactivity+level_design)/4),
	primary key (game_id,rate_id),
	foreign key (game_id) references Games ON DELETE CASCADE ,
	foreign key (member_email) references Members
	) 


	create table Game_Reviews(
	game_review_id int identity ,
	game_id int ,
	verified_reviewer varchar(50)  ,
	date smalldatetime ,
	content text,
	title text,
	primary key(game_review_id,game_id),
	foreign key (game_id)references Games ON DELETE CASCADE,
	foreign key (verified_reviewer) references Verified_Reviewers
	)


	create table Game_Reviews_Commented_On_By_Members(
	comment_id int identity,
	game_review_id int ,
	game_id int ,
	member_id varchar(50),
	content text,
	primary key (comment_id,game_review_id),
	foreign key(game_review_id,game_id)references Game_Reviews,
	foreign key (member_id) references Members ON DELETE CASCADE
	)


	create table Development_Teams_Present_Games(
	conference_id int ,
	game_id int ,
	development_team_id varchar(50),
	primary key(conference_id,game_id),
	foreign key (development_team_id) references Development_Teams,
	foreign key (conference_id) references Conferences,
	foreign key(game_id)references Games ON DELETE CASCADE
	)

	create table User1_Recommend_Games_To_User2(
	normal_user1 varchar(50),
	normal_user2  varchar(50),
	game_id int ,
	primary key (normal_user1,normal_user2,game_id),
	foreign key (normal_user1) references Normal_Users ,
	foreign key (normal_user2) references Normal_Users,
	foreign key (game_id )references Games ON DELETE CASCADE
	)

 alter table  Communities 
 add member_id varchar(50)

 alter table  Communities 
 add accept bit

 alter table Development_Teams
 add accept bit 

 alter table Verified_Reviewers
 add accept bit

