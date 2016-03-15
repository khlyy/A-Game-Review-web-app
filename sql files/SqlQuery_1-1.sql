CREATE proc Members_Sign_Up
@email varchar(50),
@password varchar(50),
@prefered_game varchar(50),
@membership_type varchar(50)
as
if(@prefered_game=any (select g.name from Games g) and (@membership_type='Normal User'or @membership_type='Verified Reviewer' or @membership_type='Development Teams'))
insert into Members values(@email,@password,@prefered_game,@membership_type)
if(@membership_type='Normal User')
insert into Normal_Users (e_mail) values (@email)
if(@membership_type='Verified Reviewer')
insert into Verified_Reviewers (e_mail) values (@email)
if(@membership_type='Development Teams')
insert into Normal_Users (e_mail) values (@email)

GO


create proc Members_Search_Games
@name varchar(50)
as
select g.game_id,g.name  
from Games g 
where g.name=@name

GO
create proc Members_Search_Conferences
@name varchar(50)
as
select con.conference_id,con.name 
from Conferences con
where con.name=@name

GO
create proc Members_Search_Communities
@name varchar(50)
as
select com.theme,com.name
from Communities com
where com.name=@name and com.accept=1


GO
create proc Members_Search_Verified_Reviewers
@name varchar(50)
as
select vr.e_mail,vr.first_name 
from Verified_Reviewers vr
where vr.first_name=@name

GO
create proc Members_Search_Development_Team
@name varchar(50)
as
select dt.e_mail,dt.team_name 
from Development_Teams dt
where dt.team_name=@name

GO
CREATE proc Members_View_Games
@game_id int
as
select G.name,G.release_date,G.rating,G.age_limit,DT.team_name, 
V.video_id,SC.screenshot_id,GR.game_review_id,ST.real_time,ACT.sub_genre,SPO.type1,PVG.story_line,PVG.pvp
from
Games G left outer join  Development_Teams DT on G.development_team_email = DT.e_mail 
		left outer join Videos V on G.game_ID = V.game_id 
		left outer join Screenshots SC on G.game_ID = SC.game_id
		left outer join Game_Reviews GR on G.game_ID = GR.game_id
		left outer join Strategies ST on G.game_ID = ST.game_id 
		left outer join Actions ACT on G.game_ID = ACT.game_id
		left outer join Sports SPO on G.game_ID = SPO.game
		left outer join RPG PVG on G.game_ID = PVG.game_id
WHERE G.game_ID=@game_id 


GO
CREATE PROC Members_Rate_Games
@graphics int,
@level_design int,
@interactivity int ,
@uniqueness int ,
@game_id int ,
@member_email varchar(50)
as
insert into Games_Rated_By_Members values (@game_id,@member_email,@graphics,@level_design,@interactivity,@uniqueness)

GO
CREATE proc Overall_Rating
@game_id int
as
declare @result int 
select @result = avg(average_rate)
from Games_Rated_By_Members g
group by g.game_id
having g.game_id=@game_id
update Games 
set rating = @result
where game_ID=@game_id
select g1.rating from Games g1
where g1.game_id=@game_id


 GO
 create PROC Presented_Games_Views_At_Conferences 
 @conference_id int
 as
 select DT.team_name , G.name
 from Development_Teams_Present_Games DTG left outer join Games G on DTG.game_id = G.game_ID 
 left outer join Development_Teams DT on DTG.development_team_id = DT.e_mail
 where  
 DTG.conference_id =@conference_id
 GROUP BY DT.team_name , G.name

 Go

 CREATE PROC Conferences_Views_By_Members 
 @conference_id int
 as
 select conference_id,name,venue,start_date,duration
 from Conferences
 where  
 conference_id =@conference_id 



 GO
 create PROC Debuted_Games_Views_At_Conferences 
 @conference_id int
 as
 select DT.team_name , G.name
 from Development_Teams_Present_Games DTG left outer join Games G on DTG.game_id = G.game_ID 
 left outer join Development_Teams DT on DTG.development_team_id = DT.e_mail
 where  
 DTG.conference_id =@conference_id and G.release_conference = @conference_id 
 GROUP BY DT.team_name , G.name

 GO
 create PROC Reviews_Views_At_Conferences 
 @conference_id int
 as
SELECT title , conference_review_id , member_id , content
 from Members_Add_Reviews_To_Conferences
 where
 conference_id =@conference_id

 GO

 CREATE PROC Conference_Review_Added_By_Members
 @member_id varchar(50),
 @conference_id int ,
 @content text,
 @date smalldatetime,
 @title text
as
  if( @conference_id = any(select CON.conference_id 
 from Members_Attend_Conferences CON   where CON.member_id=@member_id))
 insert into Members_Add_Reviews_To_Conferences values (@Conference_id,@member_id,@content,@date,@title)

 GO
 create proc Members_Join_Community   
 @member_id varchar(50),
 @theme varchar(50)
 as
 if(@theme=any(select theme from Communities c where c.theme=@theme and c.accept=1))
insert into Members_Join_Communities values (@theme,@member_id)

GO
 create proc Members_Post_Topic_On_Community
 @theme varchar(50),
 @title varchar(100),
 @description text,
 @member_id varchar(50)
 as
  if (@theme =any (select COM.theme from Members_Join_Communities COM WHERE COM.member_id=@member_id ))
 insert into Members_Post_Topic_On_Communities values (@theme,@title,@description,@member_id)


 GO
  create proc Members_Add_comment_On_Conference_Review 
  @member_id varchar(50),
  @conference_review_id int,
  @conference_id int,
  @content text
  as
  insert into Members_comment_On_Conference_Review values (@conference_review_id,@conference_id,@content,@member_id)


  GO

  create proc Members_Add_Comment_On_Game_Review 
  @member_id varchar(50),
  @game_review_id int,
  @game_id int,
  @content text
  as
  insert into Game_Reviews_Commented_On_By_Members values (@game_review_id,@game_id,@member_id,@content)

  GO
   create proc Members_Add_Comment_On_Topic
  @member_id varchar(50),
  @topic_id int,
  @theme varchar(50),
  @date smalldatetime,
  @content text
  as
  if (@theme =any (select COM.theme from Members_Join_Communities COM WHERE COM.member_id=@member_id ))
  insert into Members_Comment_On_Topics values (@theme,@topic_id,@content,@date,@member_id)


  GO
create PROC Members_Adding_attended_Conferences
@member_id VARCHAR(50) ,
@conference_id INT
AS
INSERT INTO Members_Attend_Conferences VALUES (@member_id , @conference_id)




GO
create PROC Members_Delete_Community_Topics
@member_id VARCHAR(50),
@topic_id int 
AS
DELETE FROM Members_Post_Topic_On_Communities
WHERE member_id = @member_id AND topic_id = @topic_id


GO
create PROC Members_Delete_Conference_Reviews
@member_id VARCHAR(50),
@conference_review_id int
AS
DELETE FROM Members_Add_Reviews_To_Conferences
WHERE conference_review_id = @conference_review_id AND member_id = @member_id

GO
create PROC Members_View_Communities
@community_theme VARCHAR(50),
@member_id VARCHAR(50)
AS
SELECT COM.name , COM.description , MJC.member_id , MPT.topic_id
FROM Communities COM left outer join  Members_Join_Communities MJC on COM.theme = MJC.theme
					 left outer join Members_Post_Topic_On_Communities MPT on COM.theme = MPT.theme
WHERE COM.theme = @community_theme and COM.accept=1

GO

create PROC Members_View_Community_Topics_Comments
@community_theme VARCHAR(50),
@topic_id INT,
@member_id VARCHAR(50)
AS
SELECT   MCT.comment_id,MCT.content,MCT.member_id 
FROM Members_Comment_On_Topics MCT   
WHERE MCT.topic_id = @topic_id AND MCT.theme = @community_theme
GO
create PROC Members_View_Conference_Review_Comments
@conference_review_id INT,
@conference_id INT
AS
SELECT MCC.content,MCC.member_id, MCC.comment_id
FROM Members_Comment_On_Conference_Review MCC
WHERE MCC.conference_review_id = @conference_review_id AND MCC.conference_id = @conference_id

GO
create PROC Members_View_Game_Review_Comments
@game_review_id INT,
@game_id INT
AS
SELECT GRC.comment_id
FROM Game_reviews_Commented_On_By_Members GRC
WHERE GRC.game_review_id = @game_review_id AND GRC.game_id = @game_id

GO
create  PROC Memebers_View_List_Of_Reviews_Of_Games_They_Rated
@member_id VARCHAR(50)
AS
SELECT GR.game_review_id 
FROM Game_Reviews GR left outer join Games_Rated_By_Members GRBM on GR.game_id = GRBM.game_id
					 left outer join Verified_Reviewers VR on GR.verified_reviewer = VR.e_mail
WHERE GR.verified_reviewer = @member_id
GROUP BY VR.year_of_experience , GR.game_review_id 

GO
 create proc  Members_Delete_Conference_Reviews_Comment
 @member_id varchar(50),
 @comment_id int 
 as
 delete from Members_Comment_On_Conference_Review 
 where member_id=@member_id and comment_id=@comment_id


 GO
 create proc Members_Delete_Games_Reviews_Comment
 @member_id varchar(50),
 @comment_id int 
 as
 delete from Game_Reviews_Commented_On_By_Members 
 where member_id=@member_id and comment_id=@comment_id


 GO
 create proc Members_Delete_Topics_Comment
 @member_id varchar(50),
 @comment_id int, 
 @theme varchar(50)
 as
 if (@theme =any (select COM.theme from Members_Join_Communities COM WHERE COM.member_id=@member_id ))
 delete from Members_Comment_On_Topics 
 where member_id=@member_id and comment_id=@comment_id

 GO
CREATE PROC Verified_Reviewer_Ubdate_Info
@first_name VARCHAR(50),
@last_name VARCHAR(50),
@year_of_experience INT,
@member_id VARCHAR(50)
AS 
UPDATE Verified_Reviewers
SET first_name = @first_name , last_name = @last_name , year_of_experience = @year_of_experience
WHERE e_mail = @member_id

GO
CREATE PROC Memers_Add_Game_Reviews
@game_id INT,
@member_id VARCHAR(50),
@contet TEXT,
@title text
AS
IF(@member_id = ANY(SELECT VR.e_mail FROM Verified_Reviewers VR WHERE VR.e_mail = @member_id))
INSERT INTO Game_Reviews VALUES(@game_id , @member_id , CURRENT_TIMESTAMP , @contet,@title)


GO

CREATE PROC Members_Delete_Game_Reviews
@member_id VARCHAR(50),
@game_review_id INT
AS
DELETE FROM Game_reviews
WHERE verified_reviewer = @member_id AND game_review_id = @game_review_id


GO
create proc Top_Ten_Game_Reviews
@member_id varchar(50)
as
select a.game_review_id
from
(
select top 10 GR.game_review_id,count(comment_id) as count
from Game_Reviews GR left outer join Game_Reviews_Commented_On_By_Members GRC  ON GRC.game_review_id=GR.game_review_id
where GR.verified_reviewer=@member_id
GROUP BY GR.game_review_id
ORDER BY count desc)a
GO
create proc top_five_members_Attended_Conferences_Common_With_Me
@member_id varchar(50)
as
select  a.member_id 
from(
select top 5 MA.member_id,count(member_id)as count 
 from
Members_Attend_Conferences MA 
where MA.Conference_id=any(select MA1.conference_id from Members_Attend_Conferences MA1
                           where MA1.member_id=@member_id) and MA.member_id <> @member_id
						   group by MA.member_id
						   order by count desc )a
						   
						   GO
create proc Top_Ten_Game_Recommendations
@member_id varchar(50)
as
select a.game_id
from
(
select top 10 GR.game_id,count(GR.game_id)as count 
from User1_Recommend_Games_To_User2 GR left outer join Games_Rated_By_Members GRM
on GR.game_id=GRM.game_id
where   GR.normal_user1 <>@member_id and (GR.game_id <> any(select GRM1.game_id from 
Games_Rated_By_Members GRM1
where GRM1.member_email=@member_id
 ))
group by GR.game_id 
order by count desc)a



GO
create proc Update_My_Account 
@first_name varchar(50),
@last_name varchar(50),
@date_of_birth datetime ,
@email varchar(50)
as  
update Normal_Users
set first_name = @first_name,
last_name = @last_name,
date_of_birth= @date_of_birth
where e_mail =@email

GO
create proc Send_Friend_request 
@email1 varchar (50),
@email2 varchar (50)
As
insert Members_Add_Members (e_mail1,e_mail2) values(@email1,@email2)


GO
Create proc Find_Friends 
@email varchar(50)
As  
select e_mail , first_name ,Last_name 
from Normal_Users 
where e_mail=@email 

GO
create proc View_Pending_Requests
@email varchar(50)
AS
select  e_mail1
from Members_Add_Members 
where e_mail2=@email And accept is null 
GO
Create proc  Accept_Friend_Request
@email1  varchar(50),
@email2 varchar (50)
As
update Members_Add_Members
set accept =1
where e_mail1=@email1 And e_mail2=@email2

GO
CREATE proc  Reject_Friend_Request
@email1  varchar(50),
@email2 varchar (50)
As
update Members_Add_Members
set accept =0
where e_mail1=@email1 And e_mail2=@email2

GO
CREATE proc View_Friend_List
@email varchar(50)
As
select  e_mail2 AS 'FRIENDS'
from Members_Add_Members 
where e_mail1=@email  And accept=1
union
 select e_mail1
from Members_Add_Members 
where e_mail2=@email  And accept=1
GO
CREATE proc View_Friend_Profile 
@email1 varchar (50),
@email2 varchar (50)
As 
select  N.first_name ,N.Last_name ,N.age , C.conference_id,gr.game_ID,gr.average_rate 
  from   Normal_Users N  
Left outer join Members_Attend_Conferences  c on N.e_mail=c.member_id 
 left outer join Games_Rated_By_Members  gr on N.e_mail =gr.member_email
 left outer join  Members_Add_members M on  N.e_mail=M.e_mail1  or N.e_mail=M.e_mail2
 where N.e_mail=@email2 And  M.accept=1 and ((M.e_mail1=@email1 and M.e_mail2=@email2) or (M.e_mail1=@email2 and M.e_mail2=@email1))
GO
 Create proc Recommend_Game 
 @email1 varchar (50),
 @email2 varchar (50),
 @gameid int 
 As 
insert  User1_Recommend_Games_TO_User2(normal_User1,normal_user2,game_id) values (@email1, @email2,@gameid)
GO
Create proc view_recommendations
@email varchar (50)
As 
select game_id 
from User1_Recommend_Games_TO_User2
where normal_user2=@email 

 
 GO
create proc Request_To_Create_Community 
@theme varchar(50) ,
@email varchar(50),
@name varchar(50), 
@description text
As
if(@email= any (select n.e_mail from Normal_Users n))
insert into Communities (theme,member_id,name,description) values (@theme,@email,@name,@description)
GO
create  proc Send_Message_To_Friends
@sender varchar(50),
@reciever varchar(50),
@content text
As
declare @date smalldatetime 
select @date=current_timestamp
if (1=(select M.accept 
from Members_Add_Members M
where (M.e_mail1=@sender And M.e_mail2=@reciever) or  (M.e_mail1=@reciever And M.e_mail2=@sender)  ))
insert into Member_send_Message_To_Members (sender,reciever,date ,content ) values (@sender,@reciever,@date,@content)

GO
Create proc View_My_Messages 
@email varchar(50)
As
select  *
from Member_send_Message_To_Members M
where M.reciever=@email

GO
	create proc Development_Team_Add_ScreenShot_Video
	@email varchar(50),
	@game_id int,
	@descriptionS text,
	@dateS smalldatetime,
	@descriptionV text,
	@dateV smalldatetime
	as if(@email=any (select development_team_email from Games where development_team_email=@email and game_ID=@game_id) )
	insert into Screenshots(game_id,description,date) values (@game_id,@descriptionS,@dateS)
	insert into Videos(game_id,description,date) values (@game_id,@descriptionV,@dateV)
	GO
create proc Development_Team_Add_Game
@game_ID int,
@release_conference int,
@development_team_email varchar(50)
as
insert into Development_Teams_Present_Games(game_id,development_team_id,conference_id) values(@game_ID,@development_team_email,@release_conference)


GO
create proc Development_Team_Add_Conference
@development_team_id varchar(50),
@game_id int,
@conference_id int,
@name varchar(50),
@start_date smalldatetime,
@end_date smalldatetime,
@venue varchar(100)
as
if(@development_team_id=any(select d.e_mail from Development_Teams d ))
insert into Conferences (conference_id,name,start_date,end_date,venue) values (@conference_id,@name,@start_date,@end_date,@venue)
insert into Development_Teams_Present_Games (conference_id,game_id,development_team_id) values (@conference_id,@game_id,@development_team_id)

GO
create proc Development_Teams_Update_Account
	@email varchar(50),
@team_nameUP varchar(50),
@companyUP varchar(50),
@formation_dateUP smalldatetime
as
update Development_Teams
set team_name= @team_nameUP ,company= @companyUP , formation_date= @formation_dateUP 
where e_mail=@email;

GO
create proc System_Admin_View_List_Community
as
select c.theme from Communities c where c.accept =null
GO
create proc System_Admin_Accept_Verified_Reviewers
@e_mail varchar(50)
as
update Verified_Reviewers set accept=1 where e_mail=@e_mail and accept is null
GO
create proc System_Admin_Reject_Verified_Reviewers
@e_mail varchar(50)
as
update Verified_Reviewers set accept=0 where e_mail=@e_mail and accept is null

GO
	CREATE proc System_Admin_Accept_Development_Teams
	@e_mail varchar(50)
	as
	update Development_Teams set accept=1 where e_mail=@e_mail and accept is null
	

	GO
	create  proc System_Admin_Reject_Development_Teams
	@e_mail varchar(50)
	as
	update Development_Teams set accept=0 where e_mail=@e_mail and accept is null
	
	GO
create proc System_Admin_Create_Conference
@names varchar(50),
@start_date  smalldatetime,
@end_date  smalldatetime,
@venue varchar(100),
@conference_id int
as
insert into Conferences (conference_id,name,start_date,end_date,venue) values (@conference_id,@names,@start_date,@end_date,@venue)


GO
create proc System_Admin_Create_Game
@name varchar(50),
@release_date smalldatetime,
@age_limit int,
@development_team_email varchar(50),
@release_conference int
as
insert into Games(name,release_date,rating,age_limit,development_team_email,release_conference) Values(@name,@release_date,0,@age_limit,@development_team_email,@release_conference)
GO
create proc System_Admin_Delete_Game
@game_ID int
as
delete from Games
where game_ID=@game_ID
GO
create proc System_Admin_Delete_Communities
@theme varchar(50)
as
delete from Communities
where theme=@theme and accept=1

GO
create proc System_Admin_Delete_Conferences
@conference_id int
as
delete from Conferences
where conference_id=@conference_id

GO
CREATE proc System_Admin_Accept_Community
@theme varchar(50)
as
update communities  set accept=1 where( theme=@theme and accept is null)
GO
CREATE proc System_Admin_Reject_Community
@theme varchar(50)
as
update communities set accept=0 where theme=@theme and accept  is null

