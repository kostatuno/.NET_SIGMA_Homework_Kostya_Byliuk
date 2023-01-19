
-- Select all the showtimes for the current week, including movie name, date and time of the show.

SELECT movie_name, year_film, showtime 
FROM showtimes
INNER JOIN movies USING(movie_name)
WHERE showtime >= date_trunc('week', CURRENT_DATE)

-- Select all available seats for the specific show.

-- Find seats which were never booked.

SELECT num_position AS non_booked_position, hall_id FROM hall_positions
EXCEPT
SELECT num_position, hall_positions.hall_id FROM bookings
INNER JOIN 
(showtimes INNER JOIN hall_positions ON showtimes.hall_position_id = hall_positions.hall_position_id)
ON bookings.showtime_id = showtimes.showtime_id 

-- Calculate all the money earned by each movie and display in descending order along with movies names.

SELECT movie_name, SUM(price) AS price FROM bookings
INNER JOIN showtimes ON bookings.showtime_id = showtimes.showtime_id 
GROUP BY movie_name 
UNION
SELECT movie_name, (0) AS price FROM movies

-- Show top 3 users, who spent most money in the specified dates interval.

-- Find cinema halls, which received less visitors in the last week (7 days), than in the week (another 7 days) before that.

-- Find the couples of users, who attends the shows only together.

