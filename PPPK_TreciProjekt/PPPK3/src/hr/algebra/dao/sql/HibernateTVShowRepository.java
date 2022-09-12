/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.dao.sql;

import hr.algebra.dao.Repository;
import hr.algebra.model.TVShow;
import java.util.List;
import javax.persistence.EntityManager;

/**
 *
 * @author Teodor
 */
public class HibernateTVShowRepository implements Repository<TVShow> {

    @Override
    public int add(TVShow data) throws Exception {
         try(EntityManagerWrapper wrapper = HibernateFactory.getEntityManager()) {
           EntityManager em = wrapper.get();
           
           em.getTransaction().begin();    
           TVShow tvShow = new TVShow(data);
           em.persist(tvShow);          
           em.getTransaction().commit();
           return tvShow.getIDShow();
       }
    }

    @Override
    public void update(TVShow data) throws Exception {
         try(EntityManagerWrapper wrapper = HibernateFactory.getEntityManager()) {
           EntityManager em = wrapper.get();
           
           em.getTransaction().begin();    
           em.find(TVShow.class, data.getIDShow()).updateDetails(data);          
           em.getTransaction().commit();
          
       }
    }

    @Override
    public void delete(TVShow entity) throws Exception {
         try(EntityManagerWrapper wrapper = HibernateFactory.getEntityManager()) {
           EntityManager em = wrapper.get();
           
           em.getTransaction().begin();    
           em.remove(em.contains(entity) ? entity : em.merge(entity)); //ako je tek dodan, nece ga nac stoga ga moramo mergat
           em.getTransaction().commit();
          
       }
    }

    @Override
    public TVShow select(int id) throws Exception {
        try(EntityManagerWrapper wrapper = HibernateFactory.getEntityManager()) {
           EntityManager em = wrapper.get(); //ne treba transakcija jer čitamo!!!
           
           return em.find(TVShow.class, id);
          
       }
    }

    @Override
    public List<TVShow> selectAll() throws Exception {
          try(EntityManagerWrapper wrapper = HibernateFactory.getEntityManager()) {
           EntityManager em = wrapper.get(); //zelimo izvrsiti statement iz baze
           
           return em.createNamedQuery(HibernateFactory.SELECT_ALL_SHOWS).getResultList();
          
          
       }
    }


    
}
