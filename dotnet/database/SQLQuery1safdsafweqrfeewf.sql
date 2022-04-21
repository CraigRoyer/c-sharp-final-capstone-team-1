SELECT *
FROM users;

--DROP TABLE plot;


CREATE TABLE plot 
(
--column_name			data type		constraints
	plot_id_number		int				identity(1, 1),
	user_id				int				NOT NULL, --??????????????????
	plot_length			int				NOT NULL,
	plot_width			int				NOT NULL, ------NULL OPTION??>?>
	sun_exposure_hours	nvarchar(64)	NOT NULL,
	zone_info			int				NOT NULL,
	plot_name			nvarchar(64)	NOT NULL,

	constraint pk_plot primary key (plot_id_number),
	constraint fk_user_to_plot foreign key (user_id) references users (user_id)
);


------------------------------------------------------------------------------------------------

INSERT INTO plot (user_id, plot_length, plot_width, sun_exposure_hours, zone_info, plot_name)
VALUES (4, 500, 100, 8, 1, 'Hole in the ground where I put my bad ketscups')

INSERT INTO plot (user_id, plot_length, plot_width, sun_exposure_hours, zone_info, plot_name)
VALUES (4, 19, 40, 10, 5, 'Madagascar 2')

SELECT * FROM users
JOIN plot ON users.user_id = plot.user_id

-------------------------------------------------------------------------------------


SELECT * FROM plot;

SELECT plot_width, plot_length, sun_exposure_hours, zone_info FROM plot WHERE plot_id_number = 2

SELECT * FROM plot JOIN users ON users.user_id = plot.user_id WHERE users.user_id = 4;

SELECT TOP 1 plot_name, plot_id_number, plot_length, plot_width, zone_info, sun_exposure_hours
FROM plot JOIN users ON users.user_id = plot.user_id WHERE users.user_id = 4;



--------------------------------------------------------------------------------------------------------

CREATE TABLE plants
(
--column_name			data type		constraints
	plant_id			int				identity(1, 1),
	plant_name			nvarchar(64)	NOT NULL, --??????????????????
	cost_per_25_seeds	numeric		NOT NULL,
	constraint pk_plants primary key (plant_id),
);
CREATE TABLE profiles
(
--column_name			data type		constraints
	user_id				int				identity,
	name				nvarchar(64), --??????????????????
	location			nvarchar(64),
	balance				numeric			NOT NULL
	constraint pk_profiles primary key (user_id),
	constraint fk_profiles foreign key (user_id) references users (user_id)

);

CREATE TABLE plants_users
(
--column_name			data type		constraints
	plant_id			int,
	user_id				int,

	constraint pk_plants_users primary key (plant_id, user_id),
	constraint fk_plants_users_users foreign key (user_id) references users (user_id),
	constraint fk_plants_users_plants foreign key (plant_id) references plants (plant_id)
);

CREATE TABLE plot_plants
(
--column_name			data type		constraints
	plant_id			int,
	plot_id_number		int,

	constraint pk_plot_plants primary key (plant_id, plot_id_number),
	constraint fk_plants_plot_plot foreign key (plot_id_number) references plot (plot_id_number),
	constraint fk_plants_plot_plants foreign key (plant_id) references plants (plant_id)
);

-------------------------------------------------------------------------------------------------

SELECT * FROM plants;

ALTER TABLE plants
ADD sow_instructions nvarchar(max);

ALTER TABLE plants
ADD space_instructions nvarchar(max);

ALTER TABLE plants
ADD harvest_instructions nvarchar(max);

ALTER TABLE plants
ADD compatible_plants nvarchar(max);

ALTER TABLE plants
ADD avoid_instructions nvarchar(max);

ALTER TABLE plants
ADD img_url nvarchar(max);

------------------------------
ALTER TABLE plants ALTER COLUMN cost_per_25_seeds MONEY NULL;

-------------------------------------------------------------------------------------------------

--INSERT INTO plot (user_id, plot_length, plot_width, sun_exposure_hours, zone_info, plot_name)
--OUTPUT INSERTED.plot_id_number
--VALUES(@user_id, @plot_length, @plot_width, @sun_exposure_hours, @zone_info, @plot_name)

------------

--INSERT INTO plants (plant_name, sow_instructions, space_instructions, harvest_instructions, compatible_plants, avoid_instructions, img_url)
--OUTPUT INSERTED.plant_id
--VALUES(@plant_name, @sow_instructions, @space_instructions, @harvest_instructions, @compatible_plants, @avoid_instructions, @img_url)

INSERT INTO plants_users (plant_id, user_id) 
SELECT plants_users.plant_id, plants_users.user_id
FROM plants_users
JOIN plants ON plants_users.plant_id = plants.plant_id
JOIN users ON users.user_id = plants_users.user_id
WHERE plants.plant_name = 7;

INSERT INTO plants_users (plant_id, user_id) SELECT plants_users.plant_id, plants_users.user_id FROM plants_users JOIN plants ON plants_users.plant_id = plants.plant_id JOIN users ON users.user_id = plants_users.user_id WHERE plants.plant_name = 7;

SELECT * FROM users;

SELECT * FROM plants;

SELECT * FROM plot;

SELECT plant_name, sow_instructions, space_instructions, harvest_instructions, compatible_plants, avoid_instructions, img_url FROM plants JOIN plants_users ON plants_users.plant_id = plants.plant_id JOIN users ON users.user_id = plants_users.user_id WHERE users.user_id = @users.user_id;

------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------

