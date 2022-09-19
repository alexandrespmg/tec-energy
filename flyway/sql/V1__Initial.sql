CREATE TABLE OperationallyAvailableCapacityTW (
    id SERIAL PRIMARY KEY,
    loc INTEGER,
    loc_zn TEXT,
    loc_name TEXT,
    loc_purp_desc TEXT,
    loc_qti TEXT,
    flow_ind TEXT,
    dc INTEGER,
    opc INTEGER,
    tsq INTEGER,
    oac INTEGER,
    it TEXT,
    auth_overrun_ind TEXT,
    nom_cap_exceed_ind TEXT,
    all_qty_avail TEXT,
    qty_reason TEXT
);
