namespace ArcheroLike.Enums
{
    /// <summary>
    /// Возможные состояния игры:
    /// Главное Меню
    /// Игра начата
    /// Игра на паузе
    /// Игрок проиграл
    /// Игрок прошёл уровень
    /// </summary>
    public enum GameState
    {
        MainMenu,
        Playing,
        Pause,
        GameOver,
        Victory
    }
}