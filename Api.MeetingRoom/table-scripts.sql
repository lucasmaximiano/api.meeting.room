CREATE TABLE IF NOT EXISTS meeting_room.Meetingromm (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    created_date DATE,
    number INT NOT NULL
);


CREATE TABLE IF NOT EXISTS meeting_room.MeetingRoomScheduling (
    id INT AUTO_INCREMENT PRIMARY KEY,
    created_date DATE,
    number INT NOT NULL,
    hour INT NOT NULL,
    Date DATE NOT NULL
) 