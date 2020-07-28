'use strict';
var express = require('express');
var router = express.Router();
var Tarea = require('../models/Tarea');
/* GET users listing. */
router.get('/',async function (req, res) {
    const tareas = await Tarea.findAll();
    res.json(tareas);
});

/* Post tareas creating. */
router.post('/', async function (req, res) {
    let { Titulo, Detalle, Valor, FechaEntrega } = req.body;
    let tarea = await Tarea.create({
        titulo: Titulo,
        detalle: Detalle,
        valor: Valor,
        fechaentrega: FechaEntrega
    });
    res.json(tarea);
});

/* Post tareas deleting. */
router.delete('/:id', async function (req, res) {
    const id = parseInt(req.params.id)
    return await Tarea.findByPk(id)
        .then((tareita) => tareita.destroy({ force: true }))
        .then(() => res.send({ id }))
        .catch((err) => {
            console.log('Error al eliminar', JSON.stringify(err))
            res.status(400).send(err)
        })
});


/* Post tareas updating. */
router.put('/:id', async function (req, res) {
    const id = parseInt(req.params.id)
    return await Tarea.findByPk(id).then((tareita) => {
        const { Titulo, Detalle, Valor, FechaEntrega } = req.body
        return tareita.update({
            titulo: Titulo,
            detalle: Detalle,
            valor: Valor,
            fechaentrega: FechaEntrega
        })
            .then(() => res.send(tareita))
            .catch((err) => {
                console.log('Error al actualizar', JSON.stringify(err))
                res.status(400).send(err)
            })
    })
});
module.exports = router;
