/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.dao;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Teodor
 */
public class RepositoryFactory {
    
    private static final String CLASS_NAME_PERSON="hr.algebra.dao.sql.HibernatePersonRepository"; //trebalo bi iz config file-a
    private static final String CLASS_NAME_TVSHOW="hr.algebra.dao.sql.HibernateTVShowRepository"; //trebalo bi iz config file-a

    private RepositoryFactory() {
    }
    
    private static final Repository REPO_PERSON = loadHibernatePersonRepo();
    private static final Repository REPO_SHOW = loadHibernateShowRepo();
  

    public static Repository getRepositoryPerson() {
        return REPO_PERSON;
    }
    
     public static Repository getRepositoryTVShow() {
        return REPO_SHOW;
    }
    
     private static Repository loadHibernatePersonRepo() {
        try {
            return (Repository) Class.forName(CLASS_NAME_PERSON).newInstance();
        } catch (InstantiationException | IllegalAccessException | ClassNotFoundException ex) {
            Logger.getLogger(RepositoryFactory.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;
    }
     
     private static Repository loadHibernateShowRepo() {
        try {
            return (Repository) Class.forName(CLASS_NAME_TVSHOW).newInstance();
        } catch (InstantiationException | IllegalAccessException | ClassNotFoundException ex) {
            Logger.getLogger(RepositoryFactory.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;
    }
    
}
