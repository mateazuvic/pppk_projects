/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.controller;

import hr.algebra.dao.RepositoryFactory;
import hr.algebra.model.Person;
import hr.algebra.model.TVShow;
import hr.algebra.utilities.FileUtils;
import hr.algebra.utilities.ImageUtils;
import hr.algebra.utilities.ValidationUtils;
import hr.algebra.viewmodel.PersonViewModel;
import hr.algebra.viewmodel.TVShowViewModel;
import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.IOException;
import java.net.URL;
import java.util.AbstractMap;
import java.util.Map;
import java.util.ResourceBundle;
import java.util.concurrent.atomic.AtomicBoolean;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.stream.Collectors;
import java.util.stream.Stream;
import javafx.collections.FXCollections;
import javafx.collections.ListChangeListener;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.Tab;
import javafx.scene.control.TabPane;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;

/**
 * FXML Controller class
 *
 * @author Teodor
 */
public class TVHostsController implements Initializable {

    private Map<TextField, Label> validationMap;
        
    private final ObservableList<PersonViewModel> list = FXCollections.observableArrayList();
    private final ObservableList<TVShowViewModel> listOfShows = FXCollections.observableArrayList();
    
    private PersonViewModel selectedPersonViewModel;
    private TVShowViewModel selectedTVShowViewModel;
    
    @FXML
    private TabPane tpContent;
    @FXML
    private Tab tabList;
    @FXML
    private TableColumn<PersonViewModel, String> tcFirstName, tcLastName, tcEmail;
    @FXML
    private TableColumn<PersonViewModel, Integer> tcAge;
    @FXML
    private Tab tabEdit;
    @FXML
    private ImageView ivPerson;
    @FXML
    private TextField tfFirstName;
    @FXML
    private Label lbFirstName;
    @FXML
    private TextField tfLastName;
    @FXML
    private Label lbLastName;
    @FXML
    private TextField tfAge;
    @FXML
    private Label lbAge;
    @FXML
    private TextField tfEmail;
    @FXML
    private Label lbEmail;
    @FXML
    private Label lbIcon;
    @FXML
    private TableView<PersonViewModel> tvPeople;
    @FXML
    private Tab tabListShows;
    @FXML
    private TableView<TVShowViewModel> tvShows;
    @FXML
    private TableColumn<TVShowViewModel, String> tcName;
    @FXML
    private TableColumn<TVShowViewModel, Integer> tcRating;
    @FXML
    private TableColumn<TVShowViewModel, Person> tcTVHost;
    @FXML
    private Tab tabEditShows;
    @FXML
    private TextField tfName;
    @FXML
    private TextField tfRating;
    @FXML
    private ComboBox<PersonViewModel> cbTVHost;
    @FXML
    private Button btnCommit;

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        initValidation();
        initPeople();
        initTVShows();
        initCombo();
        initTable();
        initTableShows();
        addIntMask();
        setListeners();
    }    

    @FXML
    private void edit() {
        if (tvPeople.getSelectionModel().getSelectedItem() != null) {
            bindPerson(tvPeople.getSelectionModel().getSelectedItem());
            tpContent.getSelectionModel().select(tabEdit);
        }
    }

    @FXML
    private void delete() {
        if (tvPeople.getSelectionModel().getSelectedItem() != null) {
            list.remove(tvPeople.getSelectionModel().getSelectedItem());
        }
    }

    @FXML
    private void upload() {
        File file = FileUtils.uploadFileDialog(tfAge.getScene().getWindow(), "jpg", "jpeg", "png");
        if (file != null) {
            Image image = new Image(file.toURI().toString());
            String ext = file.getName().substring(file.getName().lastIndexOf(".")+1);
            try {
                selectedPersonViewModel.getPerson().setPicture(ImageUtils.imageToByteArray(image, ext));
                ivPerson.setImage(image);
            } catch (IOException ex) {
                Logger.getLogger(TVHostsController.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
        
    }

    @FXML
    private void commit() {
        if (formValid()) {
            selectedPersonViewModel.getPerson().setFirstName(tfFirstName.getText().trim());
            selectedPersonViewModel.getPerson().setLastName(tfLastName.getText().trim());
            selectedPersonViewModel.getPerson().setAge(Integer.valueOf(tfAge.getText().trim()));
            selectedPersonViewModel.getPerson().setEmail(tfEmail.getText().trim());
            
            if (selectedPersonViewModel.getPerson().getIDPerson() == 0) {
                list.add(selectedPersonViewModel);
            } else{
                try {
                    RepositoryFactory.getRepositoryPerson().update(selectedPersonViewModel.getPerson());
                    tvPeople.refresh(); //rucna promjena
                } catch (Exception ex) {
                    Logger.getLogger(TVHostsController.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
            selectedPersonViewModel = null;
            tpContent.getSelectionModel().select(tabList); //vrati se na listu
            resetForm();
        }
        
        
    }

    private void initValidation() {
       validationMap = Stream.of(
               new AbstractMap.SimpleImmutableEntry<>(tfFirstName, lbFirstName),
               new AbstractMap.SimpleImmutableEntry<>(tfLastName, lbLastName),
               new AbstractMap.SimpleImmutableEntry<>(tfAge, lbAge),
               new AbstractMap.SimpleImmutableEntry<>(tfEmail, lbEmail)
       ).collect(Collectors.toMap(Map.Entry::getKey, Map.Entry::getValue));
    }

    private void initPeople() {
        try {
            RepositoryFactory.getRepositoryPerson().selectAll().forEach(p -> list.add(new PersonViewModel((Person) p)));
        } catch (Exception ex) {
            Logger.getLogger(TVHostsController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    private void initTable() {
        tcFirstName.setCellValueFactory(p -> p.getValue().getFirstNameProperty());
        tcLastName.setCellValueFactory(p -> p.getValue().getLastNameProperty());
        tcAge.setCellValueFactory(p -> p.getValue().getAgeProperty().asObject());
        tcEmail.setCellValueFactory(p -> p.getValue().getEmailProperty());
       
        tvPeople.setItems(list);
    }

   
    private Tab priorTab;
    private void setListeners() {
        tpContent.setOnMouseClicked(event ->{
            if (tpContent.getSelectionModel().getSelectedItem().equals(tabEdit) && !tabEdit.equals(priorTab)) {
                bindPerson(null);
            }
            else if(tpContent.getSelectionModel().getSelectedItem().equals(tabEditShows) && !tabEditShows.equals(priorTab)){
                bindShow(null);
            }
            priorTab = tpContent.getSelectionModel().getSelectedItem();
        
    });
        
        addListenersForPeople();
        addListenersForTVShows();
        
        
    }

    private void addListenersForPeople() {
        list.addListener(new ListChangeListener<PersonViewModel>() {
            @Override
            public void onChanged(ListChangeListener.Change<? extends PersonViewModel> change) {
                if(change.next()){
                    if (change.wasRemoved()) {
                        change.getRemoved().forEach(pvm -> {
                            try {
                                RepositoryFactory.getRepositoryPerson().delete(pvm.getPerson());
                            } catch (Exception ex) {
                                Logger.getLogger(TVHostsController.class.getName()).log(Level.SEVERE, null, ex);
                            }
                        });
                    } else if(change.wasAdded()){
                        change.getAddedSubList().forEach(pvm -> {
                            try {
                                int idPerson = RepositoryFactory.getRepositoryPerson().add(pvm.getPerson());
                                pvm.getPerson().setIDPerson(idPerson);
                            } catch (Exception ex) {
                                Logger.getLogger(TVHostsController.class.getName()).log(Level.SEVERE, null, ex);
                            }                     
                        });
                    }                       
                }
            }
        });
    }
    
     private void addListenersForTVShows() {
        listOfShows.addListener(new ListChangeListener<TVShowViewModel>() {
            @Override
            public void onChanged(ListChangeListener.Change<? extends TVShowViewModel> change) {
                if(change.next()){
                    if (change.wasRemoved()) {
                        change.getRemoved().forEach(pvm -> {
                            try {
                                RepositoryFactory.getRepositoryTVShow().delete(pvm.getTvShow());
                            } catch (Exception ex) {
                                Logger.getLogger(TVHostsController.class.getName()).log(Level.SEVERE, null, ex);
                            }
                        });
                    } else if(change.wasAdded()){
                        change.getAddedSubList().forEach(pvm -> {
                            try {
                                int idTVShow = RepositoryFactory.getRepositoryTVShow().add(pvm.getTvShow());
                                pvm.getTvShow().setIDShow(idTVShow);
                            } catch (Exception ex) {
                                Logger.getLogger(TVHostsController.class.getName()).log(Level.SEVERE, null, ex);
                            }                     
                        });
                    }                       
                }
            }
        });
    }

    private void bindPerson(PersonViewModel personViewModel) {
        resetForm();
        
        selectedPersonViewModel = personViewModel != null ? personViewModel : new PersonViewModel(null);
        tfFirstName.setText(selectedPersonViewModel.getFirstNameProperty().get());
        tfLastName.setText(selectedPersonViewModel.getLastNameProperty().get());
        tfEmail.setText(selectedPersonViewModel.getEmailProperty().get());
        tfAge.setText(String.valueOf(selectedPersonViewModel.getAgeProperty().get()));
        
        ivPerson.setImage(
            selectedPersonViewModel.getPictureProperty().get() != null
                ? new Image(new ByteArrayInputStream(selectedPersonViewModel.getPictureProperty().get()))
                :  new Image(new File("src/assets/tv_host.png").toURI().toString())
            
        );
    }
    
    private void bindShow(TVShowViewModel tvShowViewModel) {
        resetEditForm();
        
        selectedTVShowViewModel = tvShowViewModel != null ? tvShowViewModel : new TVShowViewModel(null);
        tfName.setText(selectedTVShowViewModel.getNameProperty().get());
        tfRating.setText(String.valueOf(selectedTVShowViewModel.getRatingProperty().get()));
        cbTVHost.setValue(selectedTVShowViewModel.getIDShowProperty().get() == 0 ? selectedTVShowViewModel.toPersonViewModel(selectedTVShowViewModel.getPersonIDProperty().get()) : null);
        
       
    }

    private void resetForm() {
        validationMap.values().forEach(lb -> lb.setVisible(false));
        lbIcon.setVisible(false);
        
    }

    private boolean formValid() {
       final AtomicBoolean ok = new AtomicBoolean(true);
       validationMap.keySet().forEach(tf -> {
           if (tf.getText().trim().isEmpty()
                   || tf.getId().contains("Email") && !ValidationUtils.isValidEmail(tf.getText().trim())) {
               ok.set(false);
               validationMap.get(tf).setVisible(true);
           } else {
                validationMap.get(tf).setVisible(false);
           }
       
       });
        if (selectedPersonViewModel.getPictureProperty().get() == null) {
            lbIcon.setVisible(true);
            ok.set(false);
        }
       
       return ok.get();
    }

    @FXML
    private void editShow() {
         if (tvShows.getSelectionModel().getSelectedItem() != null) {
             bindShow(tvShows.getSelectionModel().getSelectedItem());
            tpContent.getSelectionModel().select(tabEditShows);
        }
    }

    @FXML
    private void deleteShow() {
         if (tvShows.getSelectionModel().getSelectedItem() != null) {
            listOfShows.remove(tvShows.getSelectionModel().getSelectedItem());
        }
    }

    @FXML
    private void commitShow() {
        
            selectedTVShowViewModel.getTvShow().setName(tfName.getText().trim());
            selectedTVShowViewModel.getTvShow().setRating(Integer.valueOf(tfRating.getText().trim()));
            selectedTVShowViewModel.getTvShow().setPersonID(cbTVHost.getSelectionModel().getSelectedItem().getPerson()); 
                      
            if (selectedTVShowViewModel.getTvShow().getIDShow()== 0) {
                listOfShows.add(selectedTVShowViewModel);
            } else{
                try {
                    RepositoryFactory.getRepositoryTVShow().update(selectedTVShowViewModel.getTvShow());
                    tvShows.refresh(); //rucna promjena
                } catch (Exception ex) {
                    Logger.getLogger(TVHostsController.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
            selectedTVShowViewModel = null;
            tpContent.getSelectionModel().select(tabListShows); //vrati se na listu
            resetEditForm();
        
        
    }

    @FXML
    private void handleCommitButton() {
        btnCommit.setDisable(cbTVHost.getSelectionModel().getSelectedIndex() == -1
                || tfName.getText().trim().isEmpty()
                || tfRating.getText().trim().isEmpty());
    }

   

    private void initCombo()  {
        cbTVHost.setItems(list);
    }

    private void initTVShows() {
        try {
            RepositoryFactory.getRepositoryTVShow().selectAll().forEach(p -> listOfShows.add(new TVShowViewModel((TVShow) p)));
        } catch (Exception ex) {
            Logger.getLogger(TVHostsController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    private void initTableShows() {
        tcName.setCellValueFactory(p -> p.getValue().getNameProperty());
        tcRating.setCellValueFactory(p -> p.getValue().getRatingProperty().asObject());
        tcTVHost.setCellValueFactory(p -> p.getValue().getPersonIDProperty());
        
       
        tvShows.setItems(listOfShows);
    }

    private void addIntMask() {
        ValidationUtils.addIntegerMask(tfAge);
        ValidationUtils.addIntegerMask(tfRating);
    }

    private void resetEditForm() {
        tfName.clear();
        tfRating.setText("0");
        cbTVHost.getSelectionModel().clearSelection();
    }

   

   
    
}
