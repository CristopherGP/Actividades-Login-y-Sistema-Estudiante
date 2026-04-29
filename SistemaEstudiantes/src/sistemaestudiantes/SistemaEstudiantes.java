/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package sistemaestudiantes;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

/**
 *
 * @author Cristopher GP
 */
public class SistemaEstudiantes extends JFrame {
// Componentes
    private JTextField txtNombre, txtMatricula, txtPromedio;
    private JComboBox<String> comboCarrera;
    private JRadioButton rbMatutino, rbVespertino, rbNocturno;
    private JCheckBox cbBiblioteca, cbDeportes, cbCafeteria;
    private JTextArea areaRegistros;

    public SistemaEstudiantes() {
        setTitle("Sistema de Registro de Estudiantes");
        setSize(500, 550);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new BorderLayout());

        // Panel principal
        JPanel panel = new JPanel();
        panel.setLayout(new GridLayout(8, 2));

        // Campos
        panel.add(new JLabel("Nombre:"));
        txtNombre = new JTextField();
        panel.add(txtNombre);

        panel.add(new JLabel("Matrícula:"));
        txtMatricula = new JTextField();
        panel.add(txtMatricula);

        panel.add(new JLabel("Promedio:"));
        txtPromedio = new JTextField();
        panel.add(txtPromedio);

        // ComboBox
        panel.add(new JLabel("Carrera:"));
        comboCarrera = new JComboBox<>(new String[]{
            "Ingeniería", "Medicina", "Derecho", "Arquitectura", "Contabilidad"
        });
        panel.add(comboCarrera);

        // RadioButtons
        panel.add(new JLabel("Turno:"));
        JPanel panelRadio = new JPanel();
        rbMatutino = new JRadioButton("Matutino");
        rbVespertino = new JRadioButton("Vespertino");
        rbNocturno = new JRadioButton("Nocturno");

        ButtonGroup grupoTurno = new ButtonGroup();
        grupoTurno.add(rbMatutino);
        grupoTurno.add(rbVespertino);
        grupoTurno.add(rbNocturno);

        panelRadio.add(rbMatutino);
        panelRadio.add(rbVespertino);
        panelRadio.add(rbNocturno);

        panel.add(panelRadio);

        // CheckBox
        panel.add(new JLabel("Servicios:"));
        JPanel panelCheck = new JPanel();
        cbBiblioteca = new JCheckBox("Biblioteca");
        cbDeportes = new JCheckBox("Deportes");
        cbCafeteria = new JCheckBox("Cafetería");

        panelCheck.add(cbBiblioteca);
        panelCheck.add(cbDeportes);
        panelCheck.add(cbCafeteria);

        panel.add(panelCheck);

        // Botón
        JButton btnRegistrar = new JButton("Registrar");
        panel.add(btnRegistrar);

        add(panel, BorderLayout.NORTH);

        // Área de texto
        areaRegistros = new JTextArea();
        JScrollPane scroll = new JScrollPane(areaRegistros);
        add(scroll, BorderLayout.CENTER);

        // Evento botón
        btnRegistrar.addActionListener(e -> registrar());

        // Menú
        crearMenu();

        setVisible(true);
    }

    private void registrar() {
        try {
            String nombre = txtNombre.getText();
            String matricula = txtMatricula.getText();
            double promedio = Double.parseDouble(txtPromedio.getText());

            if (nombre.isEmpty() || matricula.isEmpty()) {
                JOptionPane.showMessageDialog(this, "Campos vacíos");
                return;
            }

            String carrera = comboCarrera.getSelectedItem().toString();

            String turno = "";
            if (rbMatutino.isSelected()) turno = "Matutino";
            else if (rbVespertino.isSelected()) turno = "Vespertino";
            else if (rbNocturno.isSelected()) turno = "Nocturno";

            String servicios = "";
            if (cbBiblioteca.isSelected()) servicios += "Biblioteca ";
            if (cbDeportes.isSelected()) servicios += "Deportes ";
            if (cbCafeteria.isSelected()) servicios += "Cafetería ";

            String registro = "Nombre: " + nombre +
                    "\nMatrícula: " + matricula +
                    "\nPromedio: " + promedio +
                    "\nCarrera: " + carrera +
                    "\nTurno: " + turno +
                    "\nServicios: " + servicios +
                    "\n----------------------\n";

            areaRegistros.append(registro);

        } catch (NumberFormatException e) {
            JOptionPane.showMessageDialog(this, "Promedio inválido");
        }
    }

    private void crearMenu() {
        JMenuBar barra = new JMenuBar();
        JMenu menu = new JMenu("Opciones");

        JMenuItem nuevo = new JMenuItem("Nuevo registro");
        JMenuItem limpiar = new JMenuItem("Limpiar lista");
        JMenuItem exportar = new JMenuItem("Exportar");
        JMenuItem salir = new JMenuItem("Salir");

        // Eventos menú
        nuevo.addActionListener(e -> limpiarCampos());
        limpiar.addActionListener(e -> areaRegistros.setText(""));
        exportar.addActionListener(e -> JOptionPane.showMessageDialog(this, "Exportado (simulado)"));
        salir.addActionListener(e -> System.exit(0));

        menu.add(nuevo);
        menu.add(limpiar);
        menu.add(exportar);
        menu.add(salir);

        barra.add(menu);
        setJMenuBar(barra);
    }

    private void limpiarCampos() {
        txtNombre.setText("");
        txtMatricula.setText("");
        txtPromedio.setText("");
    }

    public static void main(String[] args) {
        new SistemaEstudiantes();
    }
}
