use sqlx::{Row, MySqlPool};
use sqlx::mysql::MySqlRow;

struct Modl {
    idx :i32,
    name: String,
}

impl Modl {
    fn new(idx: i32, name: String) -> Modl {
        Modl {
            idx,
            name
        }
    }
}

struct Model {
    idx :i32,
    name: String,
}

impl Model {
    fn new(idx: i32, name: String) -> Model {
        Model {
            idx,
            name
        }
    }
}

#[tokio::main]
async fn main() -> Result<(), sqlx::Error> {
    println!("hello wiorld");
    let pool = MySqlPool::builder()
        .max_size(5)
        .build("mysql://root:password@localhost:9876/db").await?;
    
    let modl: Modl = sqlx::query("SELECT idx, name FROM modl")
        .map(|row: MySqlRow| {
            Modl::new(
                row.get("idx"), 
                row.get("name")
            )
        })
        .fetch_one(&pool).await?;


    println!("i: {}, n: {}", modl.idx, modl. name);
    
    let model: Model = sqlx::query("SELECT idx, name, positions FROM model")
        .map(|row: MySqlRow| {
            Model::new(
            row.get("idx"), 
            row.get("name")
        )
    })
    .fetch_one(&pool).await?;


    println!("i: {}, n: {}", model.idx, model. name);

    Ok(())
}