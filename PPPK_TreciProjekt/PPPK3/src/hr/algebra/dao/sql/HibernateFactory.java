/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.dao.sql;

import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

/**
 *
 * @author Teodor
 */
public class HibernateFactory {
    
    private static final String PERSISTENCE_UNIT = "PPPK3PU";
    public static final String SELECT_ALL  = "Person.findAll";
    public static final String SELECT_ALL_SHOWS  = "TVShow.findAll";
    
    private static final EntityManagerFactory EMF = Persistence.createEntityManagerFactory(PERSISTENCE_UNIT);
    
    public static EntityManagerWrapper getEntityManager() {
        return new EntityManagerWrapper(EMF.createEntityManager());
    }
    
    public static void release() {
        EMF.close();
    }
    
    
    
}
