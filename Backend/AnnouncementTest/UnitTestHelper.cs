using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementTest
{
    internal class UnitTestHelper
    {
        public static DbContextOptions<AppDbContext> GetUnitTestDbOptions()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new AppDbContext(options))
            {
                SeedData(context);
            }

            return options;
        }

        //Using random text generator
        public static void SeedData(AppDbContext context)
        {
            string dateOfCreation = "2005-05-05 22:12 PM";
            string dateOfChange = "2005-05-05 22:25 PM";

            var announcement1 = new Announcement()
            {
                Id = 1,
                Title = "Yet remarkably appearance get him his projection",
                Description =
                    "Improve ashamed married expense bed her comfort pursuit mrs. " +
                    "Four time took ye your as fail lady. Up greatest am exertion or marianne. Shy occasional terminated insensible and inhabiting gay." +
                    " So know do fond to half on. Now who promise was justice new winding. In finished on he speaking suitable advanced if. " +
                    "Boy happiness sportsmen say prevailed offending concealed nor was provision. " +
                    "Provided so as doubtful on striking required. Waiting we to compass assured." +
                    "\r\n\r\nSo delightful up dissimilar by unreserved it connection frequently. Do an high room so in paid. Up on cousin ye dinner should in. " +
                    "Stood tried walls manor truth shy and three his. Their to years so child truth. Honoured peculiar families sensible up likewise by on in.\r\n",
                CreatedOn = Convert.ToDateTime(dateOfCreation),
                LastModifiedOn = Convert.ToDateTime(dateOfChange)
            };
            var announcement2 = new Announcement()
            {
                Id = 2,
                Title = "The him father parish looked has sooner ",
                Description = "The him father parish looked has sooner. Attachment frequently gay terminated son. " +
                              "You greater nay use prudent placing. Passage to so distant behaved natural between do talking. " +
                              "Friends off her windows painful. Still gay event you being think nay for. In three if aware he point it. " +
                              "Effects warrant me by no on feeling settled resolve.\r\n\r\nPlacing assured be if removed it besides on." +
                              " Far shed each high read are men over day. Afraid we praise lively he suffer family estate is. Ample order up in of in ready." +
                              " Timed blind had now those ought set often which. Or snug dull he show more true wish. No at many deny away miss evil. " +
                              "On in so indeed spirit an mother. Amounted old strictly but marianne admitted. People former is remove remain as." +
                              "\r\n\r\nOut believe has request not how comfort evident. Up delight cousins we feeling minutes. Genius has looked end piqued spring. " +
                              "Down has rose feel find man. Learning day desirous informed expenses material returned six the. She enabled invited exposed him another. " +
                              "Reasonably conviction solicitude me mr at discretion reasonable. Age out full gate bed day lose."
            };
            var announcement3 = new Announcement()
            {
                Id = 3,
                Title = "The servants securing material goodness her. Saw principles themselves ten are possession",
                Description =
                    "Mr oh winding it enjoyed by between. The servants securing material goodness her. Saw principles themselves ten are possession. " +
                    "So endeavor to continue cheerful doubtful we to. Turned advice the set vanity why mutual." +
                    " Reasonably if conviction on be unsatiable discretion apartments delightful. Are melancholy appearance stimulated occasional entreaties end. " +
                    "Shy ham had esteem happen active county. Winding morning am shyness evident to. Garrets because elderly new manners however one village she." +
                    "\r\n\r\nIn up so discovery my middleton eagerness dejection explained. Estimating excellence ye contrasted insensible as. " +
                    "Oh up unsatiable advantages decisively as at interested. Present suppose in esteems in demesne colonel it to. " +
                    "End horrible she landlord screened stanhill. Repeated offended you opinions off dissuade ask packages screened. " +
                    "She alteration everything sympathize impossible his get compliment. Collected few extremity suffering met had sportsman." +
                    "\r\n\r\nFulfilled direction use continual set him propriety continued. Saw met applauded favourite deficient engrossed concealed and her. " +
                    "Concluded boy perpetual old supposing. Farther related bed and passage comfort civilly. Dashwoods see frankness objection abilities the. " +
                    "As hastened oh produced prospect formerly up am. Placing forming nay looking old married few has. " +
                    "Margaret disposed add screened rendered six say his striking confined.\r\n\r\nTo they four in love. " +
                    "Settling you has separate supplied bed. Concluded resembled suspected his resources curiosity joy. " +
                    "Led all cottage met enabled attempt through talking delight. Dare he feet my tell busy. " +
                    "Considered imprudence of he friendship boisterous."
            };
            var announcement4 = new Announcement()
            {
                Id = 4,
                Title = "Shy and subjects wondered trifling pleasant ",
                Description =
                    "Mr oh winding it enjoyed by between. The servants securing material goodness her. Saw principles themselves ten are possession. " +
                    "So endeavor to continue cheerful doubtful we to. Turned advice the set vanity why mutual." +
                    " Reasonably if conviction on be unsatiable discretion apartments delightful. Are melancholy appearance stimulated occasional entreaties end. " +
                    "Shy ham had esteem happen active county. Winding morning am shyness evident to. Garrets because elderly new manners however one village she." +
                    "\r\n\r\nIn up so discovery my middleton eagerness dejection explained. Estimating excellence ye contrasted insensible as. " +
                    "Oh up unsatiable advantages decisively as at interested. Present suppose in esteems in demesne colonel it to. " +
                    "End horrible she landlord screened stanhill. Repeated offended you opinions off dissuade ask packages screened. " +
                    "She alteration everything sympathize impossible his get compliment. Collected few extremity suffering met had sportsman." +
                    "\r\n\r\nFulfilled direction use continual set him propriety continued. Saw met applauded favourite deficient engrossed concealed and her. " +
                    "Concluded boy perpetual old supposing. Farther related bed and passage comfort civilly. Dashwoods see frankness objection abilities the. " +
                    "As hastened oh produced prospect formerly up am. Placing forming nay looking old married few has. " +
                    "Margaret disposed add screened rendered six say his striking confined.\r\n\r\nTo they four in love. " +
                    "Settling you has separate supplied bed. Concluded resembled suspected his resources curiosity joy. " +
                    "Led all cottage met enabled attempt through talking delight. Dare he feet my tell busy. " +
                    "Considered imprudence of he friendship boisterous."
            };
            var announcement5 = new Announcement()
            {
                Id = 5,
                Title = "Husbands ask repeated resolved but laughter debating.",
                Description =
                    "Pleased him another was settled for. Moreover end horrible endeavor entrance any families. Income appear extent on of thrown in admire." +
                    " Stanhill on we if vicinity material in. Saw him smallest you provided ecstatic supplied. " +
                    "Garret wanted expect remain as mr. Covered parlors concern we express in visited to do. " +
                    "Celebrated impossible my uncommonly particular by oh introduced inquietude do.\r\n\r\nWise busy past both park when an ye no. " +
                    "Nay likely her length sooner thrown sex lively income. The expense windows adapted sir. "
            };
            var announcement6 = new Announcement()
            {
                Id = 6,
                Title = "Barton waited twenty always repair in within we do",
                Description =
                    "wo before narrow not relied how except moment myself. Dejection assurance mrs led certainly." +
                    " So gate at no only none open. Betrayed at properly it of graceful on. Dinner abroad am depart ye turned hearts as me wished. " +
                    "Therefore allowance too perfectly gentleman supposing man his now. Families goodness all eat out bed steepest servants. " +
                    "Explained the incommode sir improving northward immediate eat. Man denoting received you sex possible you. Shew park own loud son door less yet." +
                    "\r\n\r\nHusbands ask repeated resolved but laughter debating. She end cordial visitor noisier fat subject general picture. " +
                    "Or if offering confined entrance no. Nay rapturous him see something residence. Highly talked do so vulgar. " +
                    "Her use behaved spirits and natural attempt say feeling. Exquisite mr incommode immediate he something ourselves it of. " +
                    "Law conduct yet chiefly beloved examine village proceed.\r\n\r\nBarton waited twenty always repair in within we do. " +
                    "An delighted offending curiosity my is dashwoods at. Boy prosperous increasing surrounded companions her nor advantages sufficient put. " +
                    "John on time down give meet help as of. Him waiting and correct believe now cottage she another. Vexed six shy yet along learn maids her tiled. " +
                    "Through studied shyness evening bed him winding present. Become excuse hardly on my thirty it wanted.\r\n\r\nSudden looked elinor off gay estate nor silent. " +
                    "Son read such next see the rest two. Was use extent old entire sussex. Curiosity remaining own see repulsive household advantage son additions. " +
                    "Supposing exquisite daughters eagerness why repulsive for. Praise turned it lovers be warmly by. Little do it eldest former be if.\r\n\r\n" +
                    "Up is opinion message manners correct hearing husband my. Disposing commanded dashwoods cordially depending at at. " +
                    "Its strangers who you certainty earnestly resources suffering she. Be an as cordially at resolving furniture preserved believing extremity. " +
                    "Easy mr pain felt in. Too northward affection additions nay. He no an nature ye talent houses wisdom vanity denied."
            };
            context.Announcements.AddRange(announcement1, announcement2, announcement3, announcement4, announcement5,
                announcement6);
        }
    }
}