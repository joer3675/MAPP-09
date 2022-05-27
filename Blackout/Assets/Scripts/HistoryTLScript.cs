
public static class HistoryTLScript
{

    private static History CURRENT_HISTORY;
    public static void setCurrentHistory(History historyObject)
    {
        CURRENT_HISTORY = historyObject;
    }
    public static History getCurrentHistory()
    {
        return CURRENT_HISTORY;
    }

}
