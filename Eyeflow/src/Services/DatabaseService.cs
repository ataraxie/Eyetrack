﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Eyeflow.Entities;

namespace Eyeflow.Services
{
    class DatabaseService
    {
        private static DatabaseService instance;

        private SQLiteConnection connection;

        private DatabaseService()
        {

        }

        public static DatabaseService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseService();
                }
                return instance;
            }
        }

        public void createDatabase()
        {
            if (this.connection != null)
            {
                throw new Exception("Database already created");
            }
            this.connection = new SQLiteConnection(Config.Instance.databaseFilePath);
            this.connection.CreateTable<GazeRecord>();
            this.connection.CreateTable<DwmRecord>();
            this.connection.CreateTable<WindowRecord>();
        }

        public void disconnect()
        {
            checkDbCreated();
            this.connection.Close();
        }

        public int writeGazeRecord(GazeRecord gaze)
        {
            checkDbCreated();
            return this.connection.Insert(gaze);
        }

        public int writeDwmRecord(DwmRecord dwm)
        {
            checkDbCreated();
            return this.connection.Insert(dwm);
        }


        private void checkDbCreated()
        {
            if (this.connection == null)
            {
                throw new Exception("No database was created");
            }
        }

    }
}
