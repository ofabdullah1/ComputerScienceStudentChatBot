USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE quotes (
	quote_id int IDENTITY(1,1) NOT NULL,
	motivational_quote varchar(500) NOT NULL,
	author varchar(50)
)

CREATE TABLE keywords (
	keyword_id int IDENTITY(1,1) NOT NULL,
	keyword varchar(50) NOT NULL,
	CONSTRAINT [PK_keywords] PRIMARY KEY (keyword_id),
)

CREATE TABLE curriculum (
	curriculum_id int IDENTITY(1,1) NOT NULL,
	response varchar(MAX) NOT NULL,
	CONSTRAINT [PK_curriculum] PRIMARY KEY (curriculum_id),
)

CREATE TABLE curriculum_keywords (
	keyword_id int NOT NULL,
	curriculum_id int NOT NULL,
	CONSTRAINT [PK_curriculum_keywords] PRIMARY KEY (keyword_id, curriculum_id),
	CONSTRAINT [FK_curriculum_keywords_keywords] FOREIGN KEY (keyword_id) REFERENCES [keywords] (keyword_id),
	CONSTRAINT [FK_curriculum_keywords_curriculum] FOREIGN KEY (curriculum_id) REFERENCES [curriculum] (curriculum_id)
)

CREATE TABLE pathway (
	pathway_id int IDENTITY(1,1) NOT NULL,
	response varchar(MAX) NOT NULL,
	CONSTRAINT [PK_pathway] PRIMARY KEY (pathway_id)
	)

CREATE TABLE pathway_keywords (
	keyword_id int NOT NULL,
	pathway_id int NOT NULL,
	CONSTRAINT [PK_pathway_keywords] PRIMARY KEY (keyword_id, pathway_id),
	CONSTRAINT [FK_pathway_keywords_keywords] FOREIGN KEY (keyword_id) REFERENCES [keywords] (keyword_id),
	CONSTRAINT [FK_pathway_keywords_pathway] FOREIGN KEY (pathway_id) REFERENCES [pathway] (pathway_id)
)

CREATE TABLE open_positions (
		position_id int IDENTITY(1,1) NOT NULL,
		job_title nvarchar(200) NOT NULL,
		company_name nvarchar(50) NOT NULL,
		city_state nvarchar(50) NULL,
		application_link nvarchar(200) NOT NULL,
		
)


--CREATE TABLE resources (
--	resource_id int IDENTITY(1,1) NOT NULL,
--	link varchar(500) NOT NULL,
--	CONSTRAINT [PK_resource] PRIMARY KEY (resource_id)
--	)

--CREATE TABLE resources_keywords (
--	keyword_id int NOT NULL,
--	resource_id int NOT NULL,
--	CONSTRAINT [PK_resources_keywords] PRIMARY KEY (keyword_id, resource_id),
--	CONSTRAINT [FK_resources_keywords_keywords] FOREIGN KEY (resource_id) REFERENCES [keywords] (keyword_id),
--	CONSTRAINT [FK_resources_keywords_resources] FOREIGN KEY (resource_id) REFERENCES [resources] (resource_id)
--)

INSERT INTO quotes (motivational_quote, author) VALUES ('You don’t lose if you get knocked down, you lose if you stay down', 'Muhammad Ali');
INSERT INTO quotes (motivational_quote, author) VALUES ('Do the difficult things while they are easy and do the great things while they are small. A journey of a thousand miles must begin with a single step', 'Lao Tzu');
INSERT INTO quotes (motivational_quote, author) VALUES ('Standard programming answer number one: ''it depends''', 'John Fulton');
INSERT INTO quotes (motivational_quote, author) VALUES ('It''s not that I''m so smart, it''s just that I stay with problems longer', 'Albert Einstein');
INSERT INTO quotes (motivational_quote, author) VALUES ('Aim above morality. Be not simply good, be good for something', 'Henry David Thoreau');
INSERT INTO quotes (motivational_quote, author) VALUES ('Do not go where the path may lead, go instead where there is no path and leave a trail.', 'Ralph Waldo Emerson');
INSERT INTO quotes (motivational_quote, author) VALUES ('The only way to do great work is to love what you do. If you haven’t found it yet, keep looking. Don’t settle', 'Steve Jobs');
INSERT INTO quotes (motivational_quote, author) VALUES ('The future belongs to those who believe in the beauty of their dreams', 'Eleanor Roosevelt');

INSERT INTO keywords (keyword) VALUES ('bool');
INSERT INTO keywords (keyword) VALUES ('string');
INSERT INTO keywords (keyword) VALUES ('data type');
INSERT INTO keywords (keyword) VALUES ('method');
INSERT INTO keywords (keyword) VALUES ('void');
INSERT INTO keywords (keyword) VALUES ('casting');
INSERT INTO keywords (keyword) VALUES ('variable');
INSERT INTO keywords (keyword) VALUES ('constant');
INSERT INTO keywords (keyword) VALUES ('behavioral interview')
INSERT INTO keywords (keyword) VALUES ('star')
INSERT INTO keywords (keyword) VALUES ('technical interview')
INSERT INTO keywords (keyword) VALUES ('best practice')
INSERT INTO keywords (keyword) VALUES ('after an interview')
INSERT INTO keywords (keyword) VALUES ('before an interview')
INSERT INTO keywords (keyword) VALUES ('attire')
INSERT INTO keywords (keyword) VALUES ('wear')


INSERT INTO curriculum (response) VALUES ('<p>a boolean true or false value</p>
<li><a href="https://www.w3schools.com/cs/cs_booleans.php" target="_blank">Click here for more info</a></li>');
INSERT INTO curriculum (response) VALUES ('<p>a piece of text some length long, may be empty, null, or have text</p>
<li><a href="https://www.w3schools.com/cs/cs_strings.php" target="_blank">Click here for more info</a></li>');
INSERT INTO curriculum (response) VALUES ('<p>what can go into a variable or a parameter and what values a method may return, examples:</p> <li>bool</li><li>string</li>
<li><a href="https://www.w3schools.com/cs/cs_data_types.php" target="_blank">Click here for more info</a></li>');
INSERT INTO curriculum (response) VALUES ('<p>smallest unit of code, may return a value, they have a name and an access modifier</p>
<li><a href="https://www.w3schools.com/cs/cs_methods.php" target="_blank">Click here for more info</a></li>');
INSERT INTO curriculum (response) VALUES ('<p>special return type that does not return any value</p>
<li><a href="https://youtu.be/CtkO4bSF94A" target="_blank">Click here for more info</a></li>');
INSERT INTO curriculum (response) VALUES ('<p>casting is converting from one data type to another datatype</p>
<li><a href="https://www.w3schools.com/cs/cs_type_casting.php" target="_blank">Click here for more info</a></li>');
INSERT INTO curriculum (response) VALUES ('<p>a metaphorical box with a name on it, stores a value of a specific type</p>
<li><a href="https://youtu.be/IxBMVztdlr4 " target="_blank">Click here for more info</a></li>');
INSERT INTO curriculum (response) VALUES ('<p>like a variable, but it cannot be changed once it is set</p>
<li><a href="https://www.w3schools.com/cs/cs_variables_constants.php" target="_blank">Click here for more info</a></li>');


INSERT INTO curriculum_keywords (keyword_id, curriculum_id) VALUES (1,1); 
INSERT INTO curriculum_keywords (keyword_id, curriculum_id) VALUES (2,2);
INSERT INTO curriculum_keywords (keyword_id, curriculum_id) VALUES (3,3);
INSERT INTO curriculum_keywords (keyword_id, curriculum_id) VALUES (4,4);
INSERT INTO curriculum_keywords (keyword_id, curriculum_id) VALUES (5,5);
INSERT INTO curriculum_keywords (keyword_id, curriculum_id) VALUES (6,6);
INSERT INTO curriculum_keywords (keyword_id, curriculum_id) VALUES (7,7);
INSERT INTO curriculum_keywords (keyword_id, curriculum_id) VALUES (8,8);

INSERT INTO pathway (response) VALUES ('<p>a structured interview technique, where they request information about a candidate''past behavior. Some example questions:</p>
<li>We''ve all had to make a decision with limited information. Tell me about a time this happened to you.</li>
<li>Give an example of a time when you were able to apply existing technology or knowledge in a new way to solve a problem.</li>
<li>Tell me about a time when you were particularly satisfied with your work situation. Why was this situation so gratifying?</li>');
INSERT INTO pathway (response) VALUES ('<p>a well known, successful tactic, to address and answer behavioral questions.</p>
<li>Situation</li>
<li>Task</li>
<li>Action</li>
<li>Result</li>
<li><a href="https://www.betterup.com/blog/star-interview-method" target="_blank">Click here for more info</a></li>');
INSERT INTO pathway (response) VALUES ('<p>interview technique that can include technical questions, whiteboarding, and/or coding problems. Some example questions:</p>
<li>What are the key principles of Object-Oriented Programming?</li>
<li>What''s an abstract class and how does it differ from an interface?</li>
<li>What is the difference between HTTP and HTTPs?</li>');
INSERT INTO pathway (response) VALUES ('<p>Best practices for technical interviews: </p>
<li>Be Honest</li>
<li>Show what you do know?</li>
<li>Take a breath</li>');
INSERT INTO pathway (response) VALUES ('<p>What to do after an interview:</p>
<li>Send a thank you</li>
<li>Keep applying to jobs</li>
<li>Be patient</li>');
INSERT INTO pathway (response) VALUES ('<p>How to prepare for an interview:</p>
<li>Research the company</li>
<li>Arrive prepared: resume, notebook/pen, phone on silent or off</li>
<li>Dress ot impress</li>
<li><a href="https://youtu.be/2EbgsRHLF9Y" target="_blank">Click here for more info</a></li>');
INSERT INTO pathway (response) VALUES ('<p>Here are some options:</p>
<li>Tops - Suit jacket, tie, button down, blouse with sweater or cardigan</li>
<li>Bottoms - Dress pants/slack, chinos, knee length dress or skirt with tights </li>
<li>Shoes - Loafers, oxfords, ballet flats, pumps</li> ');


INSERT INTO pathway_keywords (keyword_id, pathway_id) VALUES (9,1); 
INSERT INTO pathway_keywords (keyword_id, pathway_id) VALUES (10,2); 
INSERT INTO pathway_keywords (keyword_id, pathway_id) VALUES (11,3); 
INSERT INTO pathway_keywords (keyword_id, pathway_id) VALUES (12,4); 
INSERT INTO pathway_keywords (keyword_id, pathway_id) VALUES (13,5); 
INSERT INTO pathway_keywords (keyword_id, pathway_id) VALUES (14,6); 
INSERT INTO pathway_keywords (keyword_id, pathway_id) VALUES (15,7); 
INSERT INTO pathway_keywords (keyword_id, pathway_id) VALUES (16,7);

INSERT INTO open_positions (job_title, company_name, city_state, application_link) VALUES ('Jr. Software Engineer', 'JP Morgan Chase Bank, N.A.', 'Columbus, OH',
'<a href="https://www.indeed.com/jobs?q=junior+software+engineer&l=Columbus%2C+OH&vjk=f208caffed4d93c5" target="_blank">Apply here</a>');
INSERT INTO open_positions (job_title, company_name, city_state,application_link) VALUES ('Jr. Software Engineer', 'Batelle', 'Columbus, OH',
'<a href="https://www.indeed.com/jobs?q=junior+software+engineer&l=Columbus%2C+OH&vjk=e3082a07c2715c01" target="_blank">Apply here</a>');
INSERT INTO open_positions (job_title, company_name, city_state,application_link) VALUES ('Jr. Software Engineer', 'Brookesource', 'Columbus, OH',
'<a href="https://www.indeed.com/jobs?q=junior+software+engineer&l=Columbus%2C+OH&vjk=2961af50c7219738&advn=3752356117023190" target="_blank">Apply here</a>');
INSERT INTO open_positions (job_title, company_name,city_state, application_link) VALUES ('Java Developer', 'COGENT Infortech', 'Pittsburgh, PA',
'<a href="https://www.linkedin.com/jobs/view/java-developer-at-cogent-infotech-3393453303/?utm_campaign=google_jobs_apply&utm_source=google_jobs_apply&utm_medium=organic" target="_blank">Apply here</a>');
INSERT INTO open_positions (job_title, company_name,city_state, application_link) VALUES ('Java Developer', 'CGI', 'Pittsburgh, PA',
'<a href="https://www.learn4good.com/jobs/pittsburgh/pennsylvania/software_development/1879927295/e/" target="_blank">Apply here</a>');
INSERT INTO open_positions (job_title, company_name, city_state,application_link) VALUES ('C# Software Engineer', 'Emerald Resource Group', 'Cleveland, OH',
'<a href="https://www.careerbuilder.com/job/J3R031727J0NNGB0N0N?utm_campaign=google_jobs_apply&utm_source=google_jobs_apply&utm_medium=organic" target="_blank">Apply here</a>');
INSERT INTO open_positions (job_title, company_name,city_state, application_link) VALUES ('C# Software Engineer', 'National General Insurance', 'Cleveland, OH',
'<a href="https://www.glassdoor.com/job-listing/remote-software-engineer-c-national-general-insurance-JV_IC1145778_KO0,26_KE27,53.htm?jl=1008031260058&utm_campaign=google_jobs_apply&utm_source=google_jobs_apply&utm_medium=organic" target="_blank">Apply here</a>');
INSERT INTO open_positions (job_title, company_name, city_state,application_link) VALUES ('UI Frontend Developer', 'American Heart Association', 'Columbus, OH',
'<a href="https://www.linkedin.com/jobs/view/ui-front-end-developer-at-american-heart-association-3389575103/?utm_campaign=google_jobs_apply&utm_source=google_jobs_apply&utm_medium=organic" target="_blank">Apply here</a>');
INSERT INTO open_positions (job_title, company_name, city_state,application_link) VALUES ('Frontend Developer', 'Johnson, Mirmiran, & Thompson', 'Pittsburgh, PA',
'<a href="https://www.linkedin.com/jobs/view/front-end-developer-at-johnson-mirmiran-thompson-3366253838/?utm_campaign=google_jobs_apply&utm_source=google_jobs_apply&utm_medium=organic" target="_blank">Apply here</a>');
INSERT INTO open_positions (job_title, company_name, city_state,application_link) VALUES ('Backend Developer', 'Jobot', 'Cleveland, OH',
'<a href="https://www.linkedin.com/jobs/view/back-end-developer-at-jobot-3378351023/?utm_campaign=google_jobs_apply&utm_source=google_jobs_apply&utm_medium=organic" target="_blank">Apply here</a>');
INSERT INTO open_positions (job_title, company_name,city_state, application_link) VALUES ('Associate Software Engineer', 'McKesson', 'Columbus, OH',
'<a href="https://www.careerbuilder.com/job/J3V2316Y59WHT6Y4QR2?utm_campaign=google_jobs_apply&utm_medium=organic&utm_source=google_jobs_apply" target="_blank">Apply here</a>');

--populate default data

-- Robert/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Robert','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');

--Nancy/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Nancy','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO




declare @bob varchar(150)

declare @tom varchar(150)


set @tom = '%' + @bob + '%'

--SELECT * FROM curriculum 
--JOIN curriculum_keywords ck ON ck.curriculum_id = curriculum.curriculum_id
--JOIN keywords k ON k.keyword_id = ck.keyword_id
--WHERE keyword  @tom

set @bob = 'method'
SELECT response FROM curriculum 
JOIN curriculum_keywords ck ON ck.curriculum_id = curriculum.curriculum_id
JOIN keywords k ON k.keyword_id = ck.keyword_id
WHERE 'bool' LIKE keyword

--SELECT * FROM keywords WHERE keyword CONTAINS 'method'
declare @bla varchar(150)

set @bla = 'behavioral interview'
SELECT response FROM pathway 
JOIN pathway_keywords pk ON pk.pathway_id = pathway.pathway_id
JOIN keywords k ON k.keyword_id = pk.keyword_id
WHERE  'behavioral interview' Like '%' + keyword + '%';

SELECT * FROM pathway;
