CREATE DATABASE CinemaNetworkDB
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;


CREATE TABLE movies (
	movie_name VARCHAR(30) PRIMARY KEY,
	year_film DATE 
);

CREATE TABLE users(
	user_id SERIAL PRIMARY KEY,
	first_name varchar(20),
	last_name varchar(20),
	phone_number varchar(15)
);

CREATE TABLE halls (
	hall_id SERIAL PRIMARY KEY,
	address VARCHAR(30)
);

CREATE TABLE hall_positions(
	hall_position_id SERIAL PRIMARY KEY,
	num_position SERIAL,
	hall_id SERIAL REFERENCES halls(hall_id)
);

CREATE TABLE showtimes (
	showtime_id SERIAL PRIMARY KEY,
	showtime TIMESTAMP,
	price DECIMAL,
	movie_name VARCHAR(30) REFERENCES movies(movie_name),
	hall_position_id INTEGER REFERENCES hall_positions(hall_position_id)
);

CREATE TABLE bookings (
	booking_id SERIAL PRIMARY KEY,
	user_id SERIAL REFERENCES users(user_id),
	hall_id INTEGER REFERENCES halls(hall_id),
	showtime_id SERIAL REFERENCES showtimes(showtime_id)
);

INSERT INTO movies(movie_name, year_film) VALUES
('Зелена миля', '1999-05-12'),
('Побіг із Шоушенка', '1999-03-10'),
('Лицарь', '2005-09-07'),
('Мафка', '2002-10-30'),
('Тарас Бульба', '2013-02-21');

INSERT INTO users(first_name, last_name, phone_number) VALUES
('Андрій', 'Бальшивецький', '+380719920144'),
('Антон', 'Панциревич', '+380680302915'),
('Микола', 'Січ', '+380612301023'),
('Ілля', 'Мартин', '+380912305921'),
('Степан', 'Гіга', '+380912389230');

INSERT INTO halls(address) VALUES
('Житомир, вул. Проповича 81а'),
('Житомир, вул. Лобон 12'),
('Чернігів, вул. Пропасова 5'),
('Київ, вул. Андрія 41'),
('Київ, вул. Малешко 61с'),
('Луцьк, вул. Великого 51');

INSERT INTO hall_positions(num_position, hall_id) VALUES
(60, 2),
(20, 1),
(30, 3),
(40, 2),
(50, 1),
(60, 3),
(70, 4),
(40, 3),
(70, 1);

INSERT INTO showtimes(showtime, price, movie_name, hall_position_id) VALUES
('2023-01-15 14:00:00.000', 6.99, (SELECT movie_name FROM movies WHERE movie_name = 'Зелена миля' AND year_film = '1999-05-12'), (SELECT hall_position_id FROM hall_positions WHERE num_position = 20 AND hall_id = 1)),
('2023-01-15 16:00:00.000', 4.99, (SELECT movie_name FROM movies WHERE movie_name = 'Побіг із Шоушенка' AND year_film = '1999-03-10'), (SELECT hall_position_id FROM hall_positions WHERE num_position = 30 AND hall_id = 3)),
('2023-01-15 18:00:00.000', 5.99, (SELECT movie_name FROM movies WHERE movie_name = 'Лицарь' AND year_film = '2005-09-07'), (SELECT hall_position_id FROM hall_positions WHERE num_position = 40 AND hall_id = 2)),
('2023-01-15 21:00:00.000', 4.99, (SELECT movie_name FROM movies WHERE movie_name = 'Мафка' AND year_film = '2002-10-30'), (SELECT hall_position_id FROM hall_positions WHERE num_position = 50 AND hall_id = 1)),
('2023-01-18 12:00:00.000', 6.99, (SELECT movie_name FROM movies WHERE movie_name = 'Побіг із Шоушенка' AND year_film = '1999-03-10'), (SELECT hall_position_id FROM hall_positions WHERE num_position = 60 AND hall_id = 3)),
('2023-01-15 14:00:00.000', 5.99, (SELECT movie_name FROM movies WHERE movie_name = 'Зелена миля' AND year_film = '1999-05-12'), (SELECT hall_position_id FROM hall_positions WHERE num_position = 70 AND hall_id = 1));

INSERT INTO bookings(user_id, hall_id, showtime_id) VALUES
((SELECT user_id FROM users WHERE first_name = 'Андрій' AND last_name = 'Бальшивецький' AND phone_number = '+380719920144'),
(SELECT hall_id FROM halls WHERE address = 'Житомир, вул. Проповича 81а'),
(SELECT showtime_id FROM showtimes WHERE showtime = '2023-01-15 16:00:00.000' AND price = 4.99 AND movie_name = (SELECT movie_name FROM movies WHERE movie_name = 'Побіг із Шоушенка' AND year_film = '1999-03-10') AND hall_position_id = (SELECT hall_position_id FROM hall_positions WHERE num_position = 30 AND hall_id = 3))),
((SELECT user_id FROM users WHERE first_name = 'Микола' AND last_name = 'Січ' AND phone_number = '+380612301023'),
(SELECT hall_id FROM halls WHERE address = 'Чернігів, вул. Пропасова 5'),
(SELECT showtime_id FROM showtimes WHERE showtime = '2023-01-15 21:00:00.000' AND price = 4.99 AND movie_name = (SELECT movie_name FROM movies WHERE movie_name = 'Мафка' AND year_film = '2002-10-30') AND hall_position_id = (SELECT hall_position_id FROM hall_positions WHERE num_position = 50 AND hall_id = 1))),
((SELECT user_id FROM users WHERE first_name = 'Степан' AND last_name = 'Гіга' AND phone_number = '+380912389230'),
(SELECT hall_id FROM halls WHERE address = 'Київ, вул. Андрія 41'),
(SELECT showtime_id FROM showtimes WHERE showtime = '2023-01-15 18:00:00.000' AND price = 5.99 AND movie_name = (SELECT movie_name FROM movies WHERE movie_name = 'Лицарь' AND year_film = '2005-09-07') AND hall_position_id = (SELECT hall_position_id FROM hall_positions WHERE num_position = 40 AND hall_id = 2)));


