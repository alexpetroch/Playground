/*
 Design an on-line movie and event booking system

Functional
Non-Functional
Load

Client web                           Read API - > Cache ->  Storage (Read replica)
Client mobile            Load Balancer Server  Write API  -> Storage -> Master db

Functional:
User see playing moviews
User select playing movie and see cinemas
User select cinema and see times for this movie
User select time and movie, cinema and see seats
User select seat and reserve it - 
User creates booking 

Define objects:
User
Movie
Cinema
MovieView: Time, Seats
Hall contains seat, count of rows, columns
Seat: row, column
Booking
 */

using System;
using System.Collections.Generic;



#pragma warning disable CS0169, CS0649

namespace Playground.OOD
{
    class UseCases
    {
        void Start()
        {
            MovieSchedule schedule = new MovieSchedule();
            CinemaManager cinemaManager = new CinemaManager();

            // show the latest movies
            var movies = schedule.GetPlayingMovie();

            // show cinemas for selected movie
            var cinemas = cinemaManager.GetCinemaToWatch(movies[0]);

            // show times for particular ciname and movie
            var moviesView = schedule.GetMoviesView(cinemas[0], movies[0]);

            var seats = moviesView[0].GetAvailableSeats();

        }
    }

    class MovieSchedule
    {
       
        public List<Movie> GetPlayingMovie ()
        {
            return new List<Movie>();
        }

        public List<MovieView> GetMoviesView(Cinema cinema, Movie movie)
        {
            return new List<MovieView>();
        }
    }

    class CinemaManager
    {
        // list of cinemas
        // find by location
        public List<Cinema> GetCinemaByLocation()
        {
            return new List<Cinema>();
        }

        public List<Cinema> GetCinemaToWatch(Movie movie)
        {
            return new List<Cinema>();
        }
    }

    class Movie
    {
        string name;
        string genre;
    }

    class MovieView
    {
        Cinema cinema;
        DateTime time;
        List<Seat> seats;

        public List<Seat> GetAvailableSeats()
        {
            return new List<Seat>();
        }
    }

    class MoviewTicket
    {
        int id;
        Seat seat;
        Movie movie;
        Cinema cinema;
    }

    class Cinema
    {
        // get all views
        List<MovieView> activeMovieForTicketOrder;
    }

    class Seat
    {
        int row;
        int column;
        public SeatState state;
    }

    enum SeatState
    {
        Free,
        Reserved,
        Paid,
        TicketReceived
    }
}
