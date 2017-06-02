namespace Beamore.DAL.Contents
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataContext : DbContext
    {
        // Your context has been configured to use a 'DataContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Beamore.DAL.Contents.DataContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DataContext' 
        // connection string in the application configuration file.
        public DataContext()
            : base("name=DataContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Beacon> Beacons { get; set; }

        public virtual DbSet<BeaconChat> BeaconChats { get; set; }

        public virtual DbSet<BeaconNote> BeaconNotes { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<EventDetail> EventDetails { get; set; }

        public virtual DbSet<EventFlow> EventFlows { get; set; }

        public virtual DbSet<EvenFlowDetail> EvenFlowDetails { get; set; }

        public virtual DbSet<EventSubcriber> EventSubcribers { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<SentNotification> SentNotifications { get; set; }

        public virtual DbSet<Survay> Survays { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserMobileDevice> UserMobileDevices { get; set; }

        public virtual DbSet<TempUser> TempUsers { get; set; }




    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}