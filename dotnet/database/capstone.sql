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
	response varchar(500) NOT NULL,
	CONSTRAINT [PK_curriculum] PRIMARY KEY (curriculum_id),
)

CREATE TABLE curriculum_keywords (
	keyword_id int NOT NULL,
	curriculum_id int NOT NULL,
	CONSTRAINT [PK_curriculum_keywords] PRIMARY KEY (keyword_id, curriculum_id),
	CONSTRAINT [FK_curriculum_keywords_keywords] FOREIGN KEY (keyword_id) REFERENCES [keywords] (keyword_id),
	CONSTRAINT [FK_curriculum_keywords_curriculum] FOREIGN KEY (curriculum_id) REFERENCES [curriculum] (curriculum_id)
)

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

INSERT INTO curriculum (response) VALUES ('<p>a boolean true or false value</p>');
INSERT INTO curriculum (response) VALUES ('<p>a piece of text some length long, may be empty, null, or have text</p>');
INSERT INTO curriculum (response) VALUES ('<p>what can go into a variable or a parameter and what values a method may return, examples:</p> <li>bool</li><li>string</li>');
INSERT INTO curriculum (response) VALUES ('<p>smallest unit of code, may return a value, they have a name and an access modifier</p>');
INSERT INTO curriculum (response) VALUES ('<p>special return type that does not return any value</p>');
INSERT INTO curriculum (response) VALUES ('<p>casting is converting from one data type to another datatype</p>');
INSERT INTO curriculum (response) VALUES ('<p>a metaphorical box with a name on it, stores a value of a specific type</p>');
INSERT INTO curriculum (response) VALUES ('<p>like a variable, but it cannot be changed once it is set</p>');


INSERT INTO curriculum_keywords (keyword_id, curriculum_id) VALUES (1,1); 
INSERT INTO curriculum_keywords (keyword_id, curriculum_id) VALUES (2,2);
INSERT INTO curriculum_keywords (keyword_id, curriculum_id) VALUES (3,3);
INSERT INTO curriculum_keywords (keyword_id, curriculum_id) VALUES (4,4);
INSERT INTO curriculum_keywords (keyword_id, curriculum_id) VALUES (5,5);
INSERT INTO curriculum_keywords (keyword_id, curriculum_id) VALUES (6,6);
INSERT INTO curriculum_keywords (keyword_id, curriculum_id) VALUES (7,7);
INSERT INTO curriculum_keywords (keyword_id, curriculum_id) VALUES (8,8);




--populate default data

-- Robert/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Robert','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');

--Nancy/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Nancy','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO

declare @bob varchar(150)

declare @tom varchar(150)

set @bob = 'method'
set @tom = '%' + @bob + '%'

SELECT * FROM curriculum 
JOIN curriculum_keywords ck ON ck.curriculum_id = curriculum.curriculum_id
JOIN keywords k ON k.keyword_id = ck.keyword_id
WHERE keyword like @tom

SELECT response FROM curriculum 
JOIN curriculum_keywords ck ON ck.curriculum_id = curriculum.curriculum_id
JOIN keywords k ON k.keyword_id = ck.keyword_id
WHERE keyword like '%'+'method'+'%'

--SELECT * FROM keywords WHERE keyword CONTAINS 'method'



