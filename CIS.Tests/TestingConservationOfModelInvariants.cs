﻿using CinemaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace CIS.Tests
{
    public class TestingConservationOfModelInvariants
    {
        //Проверка сохранения инвариантв фильмов при конструировании 
        [Fact]
        public void Creating_a_Film_with_a_negative_year()
        {
            Assert.Throws<Exception>(() => new Film("фильм 1", "жанр", "описание", -100));
        }
        [Fact]
        public void Creating_a_Film_with_a_zero_year()
        {
            Assert.Throws<Exception>(() => new Film("фильм 1", "жанр", "описание", 0));
        }
        [Fact]
        public void Creating_a_Film_with_a_empty_name()
        {
            Assert.Throws<Exception>(() => new Film("", "жанр", "описание", 2023));
        }
        [Fact]
        public void Creating_a_Film_with_a_null_name()
        {
            Assert.Throws<Exception>(() => new Film(null, "жанр", "описание", 2023));
        }
        //Проверка сохранения инвариантв мест при конструировании 
        [Fact]
        public void Creating_a_Place_with_a_negative_row()
        {
            Assert.Throws<Exception>(() => new Place(-1, 0, 100));
        }
        [Fact]
        public void Creating_a_Place_with_a_negative_colum()
        {
            Assert.Throws<Exception>(() => new Place(0, -1, 100));
        }
        [Fact]
        public void Creating_a_Place_with_zero_price()
        {
            Assert.Throws<Exception>(() => new Place(0, 0, 0));
        }
        [Fact]
        public void Creating_a_Place_with_negative_price()
        {
            Assert.Throws<Exception>(() => new Place(0, 0, -2));
        }
        //Проверка сохранения инвариантв залов при конструировании 
        [Fact]
        public void Creating_a_Hall_with_negative_id()
        {
            int[][] places = new int[4][];
            places[0] = new int[4] { 1, 2, 3, 4 };
            places[1] = new int[4] { 5, 6, 7, 8 };
            places[2] = new int[4] { 9, 10, 11, 12 };
            places[3] = new int[4] { 13, 14, 15, 16 };
            Assert.Throws<Exception>(() => new Hall(-1, "", places));
        }
        [Fact]
        public void Creating_a_Hall_with_negative_number_place()
        {
            int[][] places = new int[4][];
            places[0] = new int[4] { -1, 2, 3, 4 };
            places[1] = new int[4] { 5, -6, 7, 8 };
            places[2] = new int[4] { 9, 10, -11, 12 };
            places[3] = new int[4] { 13, 14, 15, -16 };
            Assert.Throws<Exception>(() => new Hall(1, "3d", places));
        }
        [Fact]
        public void Creating_a_Hall_with_a_different_number_of_seats_in_a_row()
        {
            int[][] places = new int[4][];
            places[0] = new int[2] { 1, 2 };
            places[1] = new int[4] { 5, 6, 7, 8 };
            places[2] = new int[4] { 9, 10, 11, 12 };
            places[3] = new int[4] { 13, 14, 15, 16 };
            Assert.Throws<Exception>(() => new Hall(1, "3d", places));

        }
        [Fact]
        public void Creating_a_Hall_with_a_dyblicate_number_of_seats_in_row()
        {
            int[][] places = new int[4][];
            places[0] = new int[4] { 1, 2, 2, 4 };
            places[1] = new int[4] { 5, 6, 7, 8 };
            places[2] = new int[4] { 9, 10, 11, 12 };
            places[3] = new int[4] { 13, 14, 15, 16 };
            Assert.Throws<Exception>(() => new Hall(1, "3d", places));
        }
        [Fact]
        public void Creating_a_Hall_with_inconsistent_seat_numbers()
        {
            int[][] places = new int[4][];
            places[0] = new int[4] { 1, 3, 2, 4 };
            places[1] = new int[4] { 5, 6, 7, 8 };
            places[2] = new int[4] { 9, 10, 11, 12 };
            places[3] = new int[4] { 13, 14, 15, 16 };
            Assert.Throws<Exception>(() => new Hall(1, "3d", places));
        }
        //Проверка сохранения инвариантв показов при конструировании
        [Fact]
        public void Creating_a_Show_with_a_empty_name_film()
        {
            Assert.Throws<Exception>(() => new Show("", new DateOnly(2023, 10, 2), new TimeOnly(12, 10), new Seating(new int[1][], 1), 1));
        }
        [Fact]
        public void Creating_a_Show_with_a_negative_id()
        {
            Assert.Throws<Exception>(() => new Show("", new DateOnly(2023, 10, 2), new TimeOnly(12, 10), new Seating(new int[1][], 1), -1));
        }
        //Проверка сохранения инвариантв кинотеатров при конструировании 
        [Fact]
        public void Creating_a_Cinema_with_a_empty_name()
        {
            Assert.Throws<Exception>(() => new Cinema("", "адресс",4.4f, 1, new Schedule(new List<Show>()),new List<Hall>(), new Poster (new List<Film>())));
        }
        [Fact]
        public void Creating_a_Cinema_with_a_negative_id()
        {
            Assert.Throws<Exception>(() => new Cinema("название", "адресс", 4.4f, -1, new Schedule(new List<Show>()), new List<Hall>(), new Poster(new List<Film>())));
        }
        [Fact]
        public void Creating_a_Cinema_with_a_empty_address()
        {
            Assert.Throws<Exception>(() => new Cinema("название", "", 4.4f, 1, new Schedule(new List<Show>()), new List<Hall>(), new Poster(new List<Film>())));
        }
        [Fact]
        public void Creating_a_Cinema_with_negative_rating()
        {
            Assert.Throws<Exception>(() => new Cinema("название", "", -1f, 1, new Schedule(new List<Show>()), new List<Hall>(), new Poster(new List<Film>())));
        }
        //Проверка сохранения инвариантв билетов при конструировании 
        [Fact]
        public void Creating_a_Ticket_with_a_negative_id_cinema()
        {
            Assert.Throws<Exception>(() => new Ticket(-1,new Show("фильм 1", new DateOnly(2023, 10, 2), new TimeOnly(12, 10), new Seating(new int[1][], 1), 1), new Place(0, 0, 100)));
        }
        //Проверка сохранения инвариантв рассадки при конструировании
        [Fact]
        public void Creating_a_Seating_with_a_negative_id_hall()
        {
            int[][] places = new int[4][];
            places[0] = new int[4] { 100, 100, 100, 100 };
            places[1] = new int[4] { 200, 200, 200, 200 };
            places[2] = new int[4] { 200, 200, 200, 200 };
            places[3] = new int[4] {200, 200, 200, 200 };

            Assert.Throws<Exception>(() => new Seating(places,-1));
        }
        [Fact]
        public void Creating_a_Seating_with_a_different_number_of_seats_in_a_row()
        {
            int[][] places = new int[4][];
            places[0] = new int[2] { 100, 100 };
            places[1] = new int[4] { 200, 200, 200, 200 };
            places[2] = new int[4] { 200, 200, 200, 200 };
            places[3] = new int[4] { 200, 200, 200, 200 };

            Assert.Throws<Exception>(() => new Seating(places, 1));
        }
        [Fact]
        public void Creating_a_Seating_with_place_with_price_equal_minus_one()
        {
            int[][] places = new int[4][];
            places[0] = new int[2] { -1, 100 };
            places[1] = new int[4] { 200, 200, 200, 200 };
            places[2] = new int[4] { 200, 200, 200, 200 };
            places[3] = new int[4] { 200, 200, 200, 200 };

            Action testCode = () => new Seating(places, 1);
            var ex = Record.Exception(testCode);

            Assert.Null(ex);
        }
        [Fact]
        public void Creating_a_Seating_with_place_with_price_equal_zero()
        {
            int[][] places = new int[4][];
            places[0] = new int[2] { 0, 100 };
            places[1] = new int[4] { 200, 200, 200, 200 };
            places[2] = new int[4] { 200, 200, 200, 200 };
            places[3] = new int[4] { 200, 200, 200, 200 };

            Assert.Throws<Exception>(() => new Seating(places, 1));
        }
        [Fact]
        public void Creating_a_Seating_with_place_with_negative_price_without_minus_one()
        {
            int[][] places = new int[4][];
            places[0] = new int[2] { -2, 100 };
            places[1] = new int[4] { 200, 200, 200, 200 };
            places[2] = new int[4] { 200, 200, 200, 200 };
            places[3] = new int[4] { 200, 200, 200, 200 };

            Assert.Throws<Exception>(() => new Seating(places, 1));
        }
    }
}