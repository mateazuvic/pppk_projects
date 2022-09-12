package hr.algebra.personmanager.dao

import android.content.Context
import androidx.room.Database
import androidx.room.Room
import androidx.room.RoomDatabase
import androidx.room.TypeConverters
import androidx.room.migration.Migration
import androidx.sqlite.db.SupportSQLiteDatabase

@Database(entities = [Person::class],  version = 3)
@TypeConverters(DateConverter::class)
abstract class PeopleDatabase : RoomDatabase() {


    abstract fun personDao() : PersonDao

    companion object {
        @Volatile private var INSTANCE: PeopleDatabase? = null
        fun getInstance(context: Context) =
            INSTANCE ?: synchronized(PeopleDatabase::class.java) {
                INSTANCE ?: buildDatabase(context).also { INSTANCE = it }
            }


        private fun buildDatabase(context: Context) = Room.databaseBuilder(
            context.applicationContext,
            PeopleDatabase::class.java,
            "people.db")
            .addMigrations(MIGRATION_FROM_2_TO_3)
            .fallbackToDestructiveMigration().build()

        private val MIGRATION_FROM_2_TO_3=object:Migration(2,3){
            override fun migrate(database: SupportSQLiteDatabase) {
                database.execSQL("ALTER TABLE people ADD COLUMN petName TEXT")
            }

        }


    }
}