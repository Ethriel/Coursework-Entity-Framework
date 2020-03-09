use TravelAgencyLukashchuk
go
insert into UserRole
values
('Admin'),
('User')
go
insert into LoginData
values
('admin', 'qwerty'),
('user', '1')
go
insert into [User]
values
(1, 1),
(1, 1),
(1, 1),
(1, 1),
(1, 1),
(2, 2),
(2, 2),
(2, 2),
(2, 2),
(2, 2)
go
insert into Employee
values
('Jhon', 'Green', 'Manager', '+380123456789', 'jhongreen@gmail.com', '2016-02-14', 1), -- 1
('Elizabeth', 'Brown', 'Financial', '+380987456321', 'elizabethbrown@gmail.com', '2017-01-12', 2), -- 2
('Greg', 'Black', 'Owner', '+380852369741', 'gregblack@gmail.com', '2018-03-14', 3), -- 3
('Jane', 'Willson', 'HR', '+380147369852', 'janewillson@gmail.com', '2015-05-10', 4), -- 4
('Fill', 'White', 'Manager', '+380654852357', 'fillwhite@gmail.com', '2019-01-01', 5) -- 5
go
insert into Country
values
('USA'), -- 1
('UK'), -- 2
('France'), -- 3
('Germany'), -- 4
('Ukraine') -- 5
go
insert into City
values
('Dallas', 1), -- 1
('New-York', 1), -- 2
('Washington', 1), -- 3
('London', 2), -- 4
('Manchester', 2), -- 5
('Glasgo', 2), -- 6
('Paris', 3), -- 7
('Bordeaux', 3), -- 8
('Lion', 3), -- 9
('Berlin', 4), -- 10
('Munchen', 4), -- 11
('Keln', 4), -- 12
('Lviv', 5), -- 13
('Kyiv', 5), -- 14
('Uman', 5) -- 15
go
insert into Attraction
values
('Natural beauty', 100), -- 1
('Cultural', 200), -- 2
('Ancient', 300), -- 3
('Historic', 400), -- 4
('Public art', 500) -- 5
go
insert into Picture
values
('link1'),
('link2'),
('link3'),
('link4'),
('link5'),
('link6'),
('link7'),
('link8'),
('link9'),
('link10'),
('link11'),
('link12'),
('link13'),
('link14'),
('link15'),
('link16'),
('link17'),
('link18'),
('link19'),
('link20'),
('link21'),
('link22'),
('link23'),
('link24'),
('link25'),
('link26'),
('link27'),
('link28'),
('link29'),
('link30'),
('link31'),
('link32'),
('link33'),
('link34'),
('link35'),
('link36'),
('link37'),
('link38'),
('link39'),
('link40'),
('link41'),
('link42'),
('link43'),
('link44'),
('link45'),
('link46'),
('link47'),
('link48'),
('link49'),
('link50'),
('link51'),
('link52'),
('link53'),
('link54'),
('link55'),
('link56'),
('link57'),
('link58'),
('link59'),
('link60'),
('link61'),
('link62'),
('link63'),
('link64'),
('link65'),
('link66'),
('link67'),
('link68'),
('link69'),
('link70'),
('link71'),
('link72'),
('link73'),
('link74'),
('link75')
go
insert into PictureAttractions
values
(61, 1),
(62, 2),
(63, 3),
(64, 4),
(65, 5),

(66, 1),
(67, 2),
(68, 3),
(69, 4),
(70, 5),

(71, 1),
(72, 2),
(73, 3),
(74, 4),
(75, 5)
go
insert into Hotel
values
('Hotel 1', 1), --1
('Hotel 2', 1), --2
('Hotel 3', 2), --3
('Hotel 4', 2), --4
('Hotel 5', 3), --5
('Hotel 6', 3), --6
('Hotel 7', 4), --7
('Hotel 8', 4), --8
('Hotel 9', 5), --9
('Hotel 10', 5), --10
('Hotel 11', 6), --11
('Hotel 12', 6), --12
('Hotel 13', 7), --13
('Hotel 14', 7), --14
('Hotel 15', 8), --15
('Hotel 16', 8), --16
('Hotel 17', 9), --17
('Hotel 18', 9), --18
('Hotel 19', 10), --19
('Hotel 20', 10), --20
('Hotel 21', 11), --21
('Hotel 22', 11), --22
('Hotel 23', 12), --23
('Hotel 24', 12), --24
('Hotel 25', 13), --25
('Hotel 26', 13), --26
('Hotel 27', 14), --27
('Hotel 28', 14), --28
('Hotel 29', 15), --29
('Hotel 30', 15) --30
go
insert into PictureHotels
values
(1, 1), --1
(2, 1), --2
(3, 2), --3
(4, 2), --4
(5, 3), --5
(6, 3), --6
(7, 4), --7
(8, 4), --8
(9, 5), --9
(10, 5), --10
(11, 6), --11
(12, 6), --12
(13, 7), --13
(14, 7), --14
(15, 8), --15
(16, 8), --16
(17, 9), --17
(18, 9), --18
(19, 10), --19
(20, 10), --20
(21, 11), --21
(22, 11), --22
(23, 12), --23
(24, 12), --24
(25, 13), --25
(26, 13), --26
(27, 14), --27
(28, 14), --28
(29, 15), --29
(30, 15), --30
(31, 16), --31
(32, 16), --32
(33, 17), --33
(34, 17), --34
(35, 18), --35
(36, 18), --36
(37, 19), --37
(38, 19), --38
(39, 20), --39
(40, 20), --40
(41, 21), --41
(42, 21), --42
(43, 22), --43
(44, 22), --44
(45, 23), --45
(46, 23), --46
(47, 24), --47
(48, 24), --48
(49, 25), --49
(50, 25), --50
(51, 26), --51
(52, 26), --52
(53, 27), --53
(54, 27), --54
(55, 28), --55
(56, 28), --56
(57, 29), --57
(58, 29), --58
(59, 30), --59
(60, 30) --60
go
insert into Tourist
values
('Greg', 'Green', '+380123456789', 'greggreen@gmail.com', '1995-02-14', 6), -- 1
('Jane', 'Brown', '+380987456321', 'janebrown@gmail.com', '1980-01-12', 7), -- 2
('Jhon', 'Black', '+380852369741', 'johnblack@gmail.com', '2000-03-14', 8), -- 3
('Elizabeth', 'Willson', '+380147369852', 'elizabethwillson@gmail.com', '1997-05-10', 9), -- 4
('Fill', 'White', '+380654852357', 'fillwhite@gmail.com', '1999-01-01', 10) -- 5
go
insert into Tour 
values 
('Tour 1', 1000, '2019-12-25', '2020-01-02', 10, 0),--1
('Tour 2', 2000, '2020-03-05', '2020-03-15', 15, 0), --2
('Tour 3', 3500, '2020-02-03', '2020-02-13', 5, 0), --3
('Tour 4', 5000, '2019-03-04', '2019-03-14', 20, 0), --4
('Tour 5', 6000, '2020-04-05', '2020-04-15', 30, 0), --5
('Tour 6', 7000, '2020-05-01', '2020-05-11', 12, 0), --6
('Tour 7', 1500, '2020-06-02', '2020-06-12', 23, 0), --7
('Tour 8', 2300, '2020-07-13', '2020-07-23', 11, 0), --8
('Tour 9', 3400, '2020-02-09', '2020-02-19', 15, 0), --9
('Tour 10', 1200, '2019-01-30', '2019-02-15', 11, 0), --10
('Tour 11', 4500, '2020-03-10', '2020-03-20', 14, 0), --11
('Tour 12', 5210, '2020-04-05', '2020-04-15', 5, 0), --12
('Tour 13', 2341, '2019-05-14', '2019-05-24', 10, 0), --13
('Tour 14', 5000, '2020-03-13', '2020-03-23', 15, 0), --14
('Tour 15', 10000, '2020-04-17', '2020-04-27', 5, 0) --15
go
--insert into PotentionalTourists
--values
--(1, 1), --1
--(2, 2), --2
--(3, 3), --3
--(4, 4), --4
--(1, 5), --5
--(1, 1), --6
--(3, 2), --7
--(4, 2), --8
--(5, 3), --9
--(7, 4), --10
--(6, 5), --11
--(9, 2), --12
--(8, 2), --13
--(15, 1), --14
--(15, 2) --15
--go
insert into AttractionHotels
values
(1, 1), --1
(1, 2), --2
(1, 3), --3
(1, 4), --4
(1, 5), --5
(2, 6), --6
(2, 7), --7
(2, 8), --8
(2, 9), --9
(2, 10), --10
(3, 11), --11
(3, 12), --12
(3, 13), --13
(3, 14), --14
(3, 15), --15
(4, 16), --16
(4, 17), --17
(4, 18), --18
(4, 19), --19
(4, 20), --20
(5, 21), --21
(5, 22), --22
(5, 23), --23
(5, 24), --24
(5, 25), --25
(1, 26), --26
(2, 27), --27
(3, 28), --28
(4, 29), --29
(5, 30) --30
go
insert into AttractionTours
values
(1, 1), --1
(2, 2), --2
(3, 3), --3
(4, 4), --4
(5, 5), --5
(1, 6), --6
(2, 7), --7
(3, 8), --8
(4, 9), --9
(5, 10), --10
(1, 11), --11
(2, 12), --12
(3, 13), --13
(4, 14), --14
(5, 15) --15
go
--insert into TourTourists
--values
--(1, 1),
--(2, 2),
--(3, 3),
--(4, 4),
--(5, 5),
--(6, 1),
--(7, 2),
--(8, 3),
--(9, 4),
--(10, 5),
--(11, 1),
--(12, 2),
--(13, 3),
--(14, 4),
--(15, 5),

--(1, 5),
--(2, 4),
--(3, 5),
--(4, 2),
--(5, 1),
--(6, 5),
--(7, 4),
--(8, 4),
--(9, 2),
--(10, 1),
--(11, 5),
--(12, 4),
--(13, 5),
--(14, 2),
--(15, 1)
--go
insert into TourCities
values
(1, 1), --1
(1, 2), --2
(2, 3), --3
(2, 4), --4
(3, 5), --5
(3, 6), --6
(4, 7), --7
(4, 8), --8
(5, 9), --9
(5, 10), --10
(6, 11), --11
(6, 12), --12
(7, 13), --13
(7, 14), --14
(8, 15), --15
(8, 1), --16
(9, 2), --17
(9, 3), --18
(10, 4), --19
(10, 5), --20
(11, 6), --21
(11, 7), --22
(12, 8), --23
(12, 9), --24
(13, 10), --25
(13, 11), --26
(14, 12), --27
(14, 13), --28
(15, 14), --29
(15, 15) --30
go
insert into TourEmployees
values
(1, 1), --1
(2, 2), --2
(3, 4), --3
(4, 5), --4
(5, 1), --5
(6, 2), --6
(7, 4), --7
(8, 5), --8
(9, 1), --9
(10, 2), --10
(11, 4), --11
(12, 5), --12
(13, 1), --13
(14, 2), --14
(15, 4) --15
go