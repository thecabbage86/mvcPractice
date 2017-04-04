using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using mvcPractice.Models;

namespace mvcPractice.Controllers
{
    [Authorize]
    public class CharactersController : BaseController
    {
        private CharacterDBContext db;

        public CharactersController()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CharacterDBContext>());
            db = new CharacterDBContext();
        }

        // GET: Characters
        public ActionResult Index()
        {
            //TODO: use a view model
            return View(db.Characters.ToList());
        }

        // GET: Characters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            CreateEditCharacterViewModel createCharacter = new CreateEditCharacterViewModel
            {
                Intelligence = 5,
                Mind = 5,
                Strength = 5,
                Vitality = 5
            };

            return View(createCharacter);
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Intelligence,Vitality,Strength,Mind")] CreateEditCharacterViewModel createCharacter)
        {
            if (ModelState.IsValid)
            {
                Character character = new Character(createCharacter);
                character.UserId = GetUserId();
                
                db.Characters.Add(character);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(createCharacter);
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }

            return View(new CreateEditCharacterViewModel(character));
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Intelligence,Vitality,Strength,Mind")] CreateEditCharacterViewModel editCharacter)
        {
            if (ModelState.IsValid)
            {
                Character character = db.Characters.Find(editCharacter.Id);
                if (character == null)
                {
                    return HttpNotFound();
                }

                character.Name = editCharacter.Name;
                character.Intelligence = editCharacter.Intelligence;
                character.Mind = editCharacter.Mind;
                character.Strength = editCharacter.Strength;
                character.Vitality = editCharacter.Vitality;

                db.Entry(character).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editCharacter);
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Character character = db.Characters.Find(id);
            db.Characters.Remove(character);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
