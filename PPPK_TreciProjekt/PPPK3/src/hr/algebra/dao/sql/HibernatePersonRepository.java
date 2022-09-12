/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.dao.sql;

import hr.algebra.dao.Repository;
import hr.algebra.model.Person;
import java.util.List;
import javax.persistence.EntityManager;


public class HibernatePersonRepository implements Repository<Person> { //GENERICKI BI TREBAO BITI

    @Override
    public int add(Person data) throws Exception {
       try(EntityManagerWrapper wrapper = HibernateFactory.getEntityManager()) {
           EntityManager em = wrapper.get();
           
           em.getTransaction().begin();    
           Person person = new Person(data);
           em.persist(person);          
           em.getTransaction().commit();
           return person.getIDPerson();
       }
    }

    @Override
    public void update(Person person) throws Exception {
        try(EntityManagerWrapper wrapper = HibernateFactory.getEntityManager()) {
           EntityManager em = wrapper.get();
           
           em.getTransaction().begin();    
           em.find(Person.class, person.getIDPerson()).updateDetails(person);          
           em.getTransaction().commit();
          
       }
    }

    @Override
    public void delete(Person person) throws Exception {
        try(EntityManagerWrapper wrapper = HibernateFactory.getEntityManager()) {
           EntityManager em = wrapper.get();
           
           em.getTransaction().begin();    
           em.remove(em.contains(person) ? person : em.merge(person)); //ako je tek dodan, nece ga nac stoga ga moramo mergat
           em.getTransaction().commit();
          
       }
    }

    @Override
    public Person select(int id) throws Exception {
         try(EntityManagerWrapper wrapper = HibernateFactory.getEntityManager()) {
           EntityManager em = wrapper.get(); //ne treba transakcija jer čitamo!!!
           
           return em.find(Person.class, id);
          
       }
    }

    @Override
    public List<Person> selectAll() throws Exception {
        try(EntityManagerWrapper wrapper = HibernateFactory.getEntityManager()) {
           EntityManager em = wrapper.get(); //zelimo izvrsiti statement iz baze
           
           return em.createNamedQuery(HibernateFactory.SELECT_ALL).getResultList();
          
          
       }
    }

    @Override
    public void release() throws Exception {
        HibernateFactory.release();
    }

   
    
}
