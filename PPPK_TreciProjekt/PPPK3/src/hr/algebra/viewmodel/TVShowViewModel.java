/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.viewmodel;

import hr.algebra.model.Person;
import hr.algebra.model.TVShow;
import javafx.beans.property.IntegerProperty;
import javafx.beans.property.ObjectProperty;
import javafx.beans.property.SimpleIntegerProperty;
import javafx.beans.property.SimpleObjectProperty;
import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;

/**
 *
 * @author Teodor
 */
public class TVShowViewModel {
    
    private final TVShow tvShow;

    public TVShowViewModel(TVShow tvShow) {
        if (tvShow == null) {
            tvShow = new TVShow(0, "", 0);
        }
        this.tvShow = tvShow;
    }

    public TVShow getTvShow() {
        return tvShow;
    }
    
    public IntegerProperty getIDShowProperty() {
        return new SimpleIntegerProperty(tvShow.getIDShow());
    }
    
    public StringProperty getNameProperty() {
        return new SimpleStringProperty(tvShow.getName());
    }
    
     public IntegerProperty getRatingProperty() {
        return new SimpleIntegerProperty(tvShow.getRating());
    }
     
        public ObjectProperty<Person> getPersonIDProperty() {
        return new SimpleObjectProperty<>(tvShow.getPersonID());
    }
        
     public PersonViewModel toPersonViewModel(Person p){
         return new PersonViewModel(p);
         
     }
    
    
}
