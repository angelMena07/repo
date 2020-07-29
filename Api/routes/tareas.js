'use strict';
var Tarea = require('../models/Tarea');
var express = require('express');
var router = express.Router();

/* GET tareas listing. */
router.get('/', async function (req, res) {
    const tareas = await Tarea.findAll();
    res.json(tareas);
});

/* GET tareas listing. */
router.post('/', async function (req, res) {
    let { Titulo, Detalle, Materia, Fecha } = req.body;
    let tarea = await Tarea.create({
        titulo: Titulo,
        detalle: Detalle,
        materia: Materia,
        fecha: Fecha
    });

    res.json(tarea);
});

/* PUT tareas listing. */
router.put('/:id', async function (req, res) {
    let id = req.params.id;
    let { Titulo, Detalle, Materia, Fecha } = req.body;
    let tarea = await Tarea.findByPk(id);
    tarea.titulo = Titulo;
    tarea.detalle = Detalle;
    tarea.materia = Materia,
    tarea.fecha = Fecha;
    await tarea.save();
    res.json(tarea);
});

/* DELETE tareas listing. */
router.delete('/:id', async function (req, res) {
    let id = req.params.id;
    let tarea = await Tarea.findByPk(id);
    tarea.destroy();
    res.json(tarea);
});

module.exports = router;
