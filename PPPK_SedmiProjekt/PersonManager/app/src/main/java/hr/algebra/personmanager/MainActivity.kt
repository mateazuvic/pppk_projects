package hr.algebra.personmanager

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import androidx.navigation.findNavController
import androidx.navigation.ui.AppBarConfiguration
import androidx.navigation.ui.navigateUp
import androidx.navigation.ui.setupActionBarWithNavController
import android.view.Menu
import android.view.MenuItem
import androidx.appcompat.app.AlertDialog
import androidx.navigation.NavController
import hr.algebra.personmanager.databinding.ActivityMainBinding

class MainActivity : AppCompatActivity() {

    private lateinit var appBarConfiguration: AppBarConfiguration
    private lateinit var binding: ActivityMainBinding
    private lateinit var navController: NavController

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        initNavigation()


    }

    private fun initNavigation() {
        setSupportActionBar(binding.toolbar)

        navController = findNavController(R.id.nav_host_fragment_content_main)
        appBarConfiguration = AppBarConfiguration(navController.graph)
        setupActionBarWithNavController(navController, appBarConfiguration)
    }

    override fun onCreateOptionsMenu(menu: Menu?): Boolean {
        menuInflater.inflate(R.menu.main_menu, menu)
        return true
    }

    override fun onOptionsItemSelected(item: MenuItem): Boolean {
        when(item.itemId) {
            R.id.menuExit -> {
                exitApp()
                return true
            }
            R.id.menuAbout -> {
                showAbout()
                return true
            }
        }

        return super.onOptionsItemSelected(item)
    }

    private fun showAbout() {
        val transaction = supportFragmentManager.beginTransaction()
        transaction.replace(R.id.list_fragment, AboutFragment())
        transaction.disallowAddToBackStack()
        transaction.commit()

    }

    private fun exitApp() {
        AlertDialog.Builder(this).apply {
            setTitle(R.string.exit)
            setMessage(getString(R.string.exit_app_question))
            setIcon(R.drawable.exit)
            setCancelable(true)
            setNegativeButton("Cancel", null)
            setPositiveButton("Ok") { _, _ -> finish()}
            show()
        }
    }



    override fun onSupportNavigateUp(): Boolean {
        return navController.navigateUp(appBarConfiguration)
                || super.onSupportNavigateUp()
    }



}