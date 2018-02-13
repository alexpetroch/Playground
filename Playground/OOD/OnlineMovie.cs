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

namespace Playground.OOD
{
    class UseCases
    {
        void Start()
        {
            MovieSchedule schedule = new MovieSchedule();
            var movies = schedule.GetPlayingMovie();

            // select movie and find cinemas
        }
    }


    class MovieSchedule
    {
        // find movie view
        public List<Movie> GetPlayingMovie ()
        {
            return new List<Movie>();
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
        List<OrderSeat> seats;
    }

    class Cinema
    {
        // get all views
    }

    class Hall
    {
        List<Seat> seats;
    }

    class Seat
    {
        int row;
        int column;
    }

    class OrderSeat
    {
        public OrderSeat(Seat seat)  { }
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
