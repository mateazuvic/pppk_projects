/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.utilities;

import java.util.function.UnaryOperator;
import java.util.regex.Pattern;
import javafx.scene.control.TextField;
import javafx.scene.control.TextFormatter;
import javafx.util.converter.IntegerStringConverter;

/**
 *
 * @author daniel.bele
 */
public class ValidationUtils {

    private ValidationUtils() {
    }

    public static boolean isValidEmail(String email) {
        return Pattern
                .compile("^[\\w!#$%&'*+/=?`{|}~^-]+(?:\\.[\\w!#$%&'*+/=?`{|}~^-]+)*@(?:[a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$")
                .matcher(email).matches();
    }

     public static void addIntegerMask(TextField tf) {
        UnaryOperator<TextFormatter.Change> filter = change -> {
            String input = change.getText();
            if (input.matches("\\d*")) {
                return change;
            }
            return null;
        };
       tf.setTextFormatter(new TextFormatter<>(new IntegerStringConverter(), 0, filter));
    }
}
