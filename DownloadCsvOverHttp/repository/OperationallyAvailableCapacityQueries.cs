namespace DownloadCsvOverHttp.repository;

public static class OperationallyAvailableCapacityQueries
{
    public static readonly string Insert =
        "INSERT INTO OperationallyAvailableCapacityTW " +
        "(loc, loc_zn, loc_name, loc_purp_desc, loc_qti, flow_ind, dc, opc, tsq, oac, it, " +
        "auth_overrun_ind, nom_cap_exceed_ind, all_qty_avail, qty_reason) " +
        "VALUES ($1, $2, $3, $4, $5, $6, $7, $8, $9, $10, $11, $12, $13, $14, $15)";
}
