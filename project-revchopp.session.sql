SELECT bt.id_barril_tipo, bt.nome, SUM(cb.ml_utilizado) as total
FROM ConsumoBarril cb
JOIN BarrilInstancia bi ON bi.id_barril_instancia = cb.id_barril_instancia
JOIN BarrilTipo bt ON bt.id_barril_tipo = bi.id_barril_tipo
JOIN Venda v ON v.id_venda = cb.id_venda
WHERE v.data_hora BETWEEN '2025-07-01' AND '2025-07-02'
GROUP BY bt.id_barril_tipo, bt.nome;